
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Threading;

namespace Omlet.Droid.Classes.BillingV3
{
	public class InAppHelper : IDisposable
	{
		private const string TestProduct = "android.test.purchased";

		private const int TimeoutForConsumption = 1000;

		private const int MaxTryesConsumption = 10;

		private Activity _activity;

		private BillingServiceWrapper _serviceWrapper;

		private ISecurityKey _securityKey;

		private Action _initializationFinished;

		public bool PurchasesEnabled { get; private set; }

		private void OnInitializationFinished(bool successed)
		{
			PurchasesEnabled = successed;
			_initializationFinished();
		}

		public void Initialize(Action initializationFinished)
		{
			_initializationFinished = initializationFinished;
			_serviceWrapper = new BillingServiceWrapper(_activity, OnInitializationFinished);
		}

		public InAppHelper(ISecurityKey securityKey, Activity activity)
		{
			_securityKey = securityKey;
			_activity = activity;
		}

		// Workaround to bug where sometimes response codes come as Long instead of Integer
		private int GetResponseCodeFromBundle(Bundle bundle)
		{
			object resultObject = bundle.Get(BillingResponse.ResponseCode);
			if (resultObject == null)
			{
				//	logDebug("Bundle with null response code, assuming OK (known issue)");
				return BillingResponseResult.OK;
			}
			else if (resultObject is Java.Lang.Integer)
			{
				return (resultObject as Java.Lang.Integer).IntValue();
			}
			else if (resultObject is long) 
			{
				return (int)((resultObject as Java.Lang.Long).LongValue());
			}
			else
			{
				//	logError("Unexpected type for bundle response code.");
				throw new Exception("Unexpected type for bundle response code: " + resultObject.GetType().Name);
			}
		}

		private IEnumerable<Purchase> GetPurchases(PurchaseItemType itemType)
		{
			var purchaseResultList = new List<Purchase>();

			string continueToken = null;
			do
			{
				var ownedItems = _serviceWrapper.GetPurchases(itemType, continueToken);
				int response = GetResponseCodeFromBundle(ownedItems);
				if (response != BillingResponseResult.OK)
				{
					throw new Exception("Result from GetPurchases is not OK");
				}
				if (!ownedItems.ContainsKey(BillingResponse.RESPONSE_INAPP_ITEM_LIST)
				    || !ownedItems.ContainsKey(BillingResponse.RESPONSE_INAPP_PURCHASE_DATA_LIST)
				    || !ownedItems.ContainsKey(BillingResponse.RESPONSE_INAPP_SIGNATURE_LIST))
				{
					throw new Exception("Result from GetPurchases doesn't contain neccessary keys");
				}
				var ownedProductIds = ownedItems.GetStringArrayList(BillingResponse.RESPONSE_INAPP_ITEM_LIST);
				var purchaseDataList = ownedItems.GetStringArrayList(BillingResponse.RESPONSE_INAPP_PURCHASE_DATA_LIST);
				var signatureList = ownedItems.GetStringArrayList(BillingResponse.RESPONSE_INAPP_SIGNATURE_LIST);
				for (int i = 0; i < purchaseDataList.Count(); i++)
				{
					string purchaseData = purchaseDataList.ElementAt(i);
					string signature = signatureList.ElementAt(i);
					string productId = ownedProductIds.ElementAt(i);

					if (string.IsNullOrEmpty(productId))
					{
						throw new Exception("Product id is empty");
					}

					if (productId == TestProduct || Security.VerifyDataSignature(purchaseData, signature, _securityKey))
					{
						var purchase = new Purchase(itemType, purchaseData, signature);
						purchaseResultList.Add(purchase);
					}
					else
					{
						throw new Exception("Verification failed");
					}
				}

				continueToken = ownedItems.GetString(BillingResponse.INAPP_CONTINUATION_TOKEN);
			}
			while (!string.IsNullOrEmpty(continueToken));

			return purchaseResultList;
		}

		private void ConsumeItem(Purchase itemInfo)
		{
			String token = itemInfo.Token;
			String productId = itemInfo.ProductId;
			if (string.IsNullOrEmpty(token))
			{
				//logError("Can't consume "+ product + ". No token.");
				throw new Exception("PurchaseInfo is missing token for product: " + productId + " " + itemInfo);
			}
			//logDebug("Consuming product: " + product + ", token: " + token);
			int response = _serviceWrapper.ConsumePurchase(token);
			if (response == BillingResponseResult.OK)
			{
			//	logDebug("Successfully consumed product: " + product);
			}
			else
			{
			//	logDebug("Error consuming consuming product " + product + ". " + getResponseDesc(response));
				throw new Exception("Error consuming product " + productId);
			}
		}

		private void PurchaseItem(string productId, PurchaseItemType itemType, string developerPayload)
		{
			//logDebug("Constructing buy intent for " + product + ", item type: " + itemType);
			Bundle buyIntentBundle = _serviceWrapper.GetBuyIntent(productId, itemType, developerPayload);
			int response = GetResponseCodeFromBundle(buyIntentBundle);
			if (response != BillingResponseResult.OK)
			{
				//logError("Unable to buy item, Error response: " + getResponseDesc(response));
				throw new Exception("Unable to buy item");
			}
			PendingIntent pendingIntent = buyIntentBundle.GetParcelable(BillingResponse.RESPONSE_BUY_INTENT) as PendingIntent;
			//logDebug("Launching buy intent for " + product + ". Request code: " + requestCode);
			_requestCode = IdGenerator.Next();
			_purchaseItemType = itemType;
			_activity.StartIntentSenderForResult(pendingIntent.IntentSender, _requestCode, new Intent(), 0, 0, 0);
		}

		private int _requestCode;

		private PurchaseItemType _purchaseItemType;

		public Purchase GetPurchaseFromActivityResult(int requestCode, Result result, Intent data)
		{
			Purchase resultPurchase;

			if (requestCode != _requestCode)
			{
				return null;
			}
			if (data == null)
			{
				throw new Exception("Bad response from activity result");
			}
			int responseCode = GetResponseCodeFromBundle(data.Extras);
			String purchaseData = data.GetStringExtra(BillingResponse.RESPONSE_INAPP_PURCHASE_DATA);
			String dataSignature = data.GetStringExtra(BillingResponse.RESPONSE_INAPP_SIGNATURE);

			if (result == Result.Ok && responseCode == BillingResponseResult.OK)
			{
				if (string.IsNullOrEmpty(purchaseData))
				{
					throw new Exception("Bad response from activity result: no data");
				}

				resultPurchase = new Purchase(_purchaseItemType, purchaseData, dataSignature);

				if (resultPurchase.ProductId != TestProduct)
				{
					if (string.IsNullOrEmpty(dataSignature))
					{
						throw new Exception("Signature is empty");
					}
					if (!Security.VerifyDataSignature(purchaseData, dataSignature, _securityKey))
					{
						throw new Exception("Verification failed");
					}
				}
			}
			else if (result == Result.Ok)
			{
				throw new Exception("Bad response from activity result: bad response");
			}
			else if (result == Result.Canceled)
			{
				return null;
			}
			else
			{
				throw new Exception("Purchase failed");
			}
			return resultPurchase;
		}

		public void StartPurchase(string productId, PurchaseItemType itemType, string developerPayload, bool consumable)
		{
			ThreadPool.QueueUserWorkItem((st) =>
			{
				var purchases = GetPurchases(itemType);
				var currentItemPurchases = purchases.Where(purchase => purchase.ProductId == productId);
				if (currentItemPurchases.Any())
				{
					var currentItemPurchase = currentItemPurchases.First();
					if (consumable)
					{
						ConsumeItem(currentItemPurchase);
						int consumptionTryCount = 0;
						bool purchaseConsumed = false;
						do
						{
							Thread.Sleep(TimeoutForConsumption);
							var newPurchases = GetPurchases(itemType);
							var newCurrentItemPurchases = newPurchases.Where(purchase => purchase.ProductId == productId);
							purchaseConsumed = !newCurrentItemPurchases.Any();
							consumptionTryCount++;
						}
						while (consumptionTryCount < MaxTryesConsumption && !purchaseConsumed);
					}
				}
				PurchaseItem(productId, itemType, developerPayload);
			});
		}

		public void Dispose()
		{
			_serviceWrapper.Dispose();
		}
	}
}

