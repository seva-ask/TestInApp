
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
using Com.Android.Vending.Billing;
using System.Threading;

namespace Omlet.Droid.Classes.BillingV3
{
	// SKU = productID
	// http://developer.android.com/google/play/billing/billing_overview.html
	public class BillingServiceWrapper : IDisposable
	{
		private const int CurrentBillingVersion = 3;

		private bool _isServiceBinded = false;

		private IInAppBillingService _service;

		private BillingServiceConnection _serviceConnection;

		private Context _context;

		private Action<bool> _initializationFinishedCallback;

		public BillingServiceWrapper(Context context, Action<bool> initializationFinishedCallback)
		{
			_context = context;
			_initializationFinishedCallback = initializationFinishedCallback;

			_serviceConnection = new BillingServiceConnection(ServiceConnectedHandler, () => _isServiceBinded = false );
			
			Intent serviceIntent = new Intent("com.android.vending.billing.InAppBillingService.BIND");
			
			if (_context.PackageManager.QueryIntentServices(serviceIntent, 0).Any())
			{
				_context.BindService(serviceIntent, _serviceConnection, Bind.AutoCreate);
				_isServiceBinded = true;
			}
			else
			{
				_initializationFinishedCallback(false);
			}
		}

		private void ServiceConnectedHandler(IInAppBillingService service)
		{
			_service = service;
			ThreadPool.QueueUserWorkItem((st) =>
			{
				try
				{
					int itemTypeInAppSupported = IsBillingSupported(PurchaseItemType.InApp);
					if (itemTypeInAppSupported != BillingResponseResult.OK)
					{
						_initializationFinishedCallback(false);
						return;
					}
					
					int itemTypeSubscriptionSupported = IsBillingSupported(PurchaseItemType.Subscription);
					if (itemTypeSubscriptionSupported != BillingResponseResult.OK)
					{
						_initializationFinishedCallback(false);
						return;
					}	
				}
				catch (Exception)
				{
					_initializationFinishedCallback(false);
					return;
				}
				_initializationFinishedCallback(true);
			});
		}

		public void Dispose()
		{
			if(_isServiceBinded)
				_context.UnbindService(_serviceConnection);
		}

		private string PackageName
		{
			get
			{
				return _context.PackageName;
			}
		}

#region Service Members
		
		public int IsBillingSupported(PurchaseItemType type)
		{
			return _service.IsBillingSupported(CurrentBillingVersion, PackageName, (string)type);
		}
		
		// not needed for us
		//		public Bundle GetProductsDetails(PurchaseItemType type, Bundle productsBundle)
		//		{
		//			return _service.GetSkuDetails(CurrentBillingVersion, _packageName, (string)type, productsBundle);
		//		}
		
		public Bundle GetBuyIntent(string productId, PurchaseItemType type, string developerPayload)
		{
			return _service.GetBuyIntent(CurrentBillingVersion, PackageName, productId, (string)type, developerPayload);
		}
		
		public Bundle GetPurchases(PurchaseItemType type, string continuationToken)
		{
			return _service.GetPurchases(CurrentBillingVersion, PackageName, (string)type, continuationToken);
		}
		
		public int ConsumePurchase(string purchaseToken)
		{
			return _service.ConsumePurchase(CurrentBillingVersion, PackageName, purchaseToken);
		}
		
#endregion Service Members
	}
}

