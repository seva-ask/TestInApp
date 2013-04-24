using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace InAppTest
{
	[Activity (Label = "InAppTest", MainLauncher = true)]
	public class Activity1 : Activity
	{
		private TestInAppManager InAppManager{get; set;}

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			InAppManager = new TestInAppManager(this);

			var mainView = new MainView(this);
			mainView.Buy += OnBuy;
			SetContentView(mainView);
		}

		void OnBuy ()
		{
			InAppManager.StartPurchase();
		}

		protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
		{
			base.OnActivityResult (requestCode, resultCode, data);
			
			var purchase = InAppManager.GetPurchaseFromActivityResult(requestCode, (Result)resultCode, data);
			
			if (purchase != null)
			{
				OnPurchaseSucceed(purchase.OrderId, purchase.PurchaseTime, purchase.ProductId);
			}
			else
			{
				OnPurchaseFailed();
			}
		}

		private void OnPurchaseSucceed(string orderId, long purchaseTime, string productId)
		{
			Toast.MakeText(this, string.Format("PurchaseSucceed orderId = {0}, purchaseTime = {1}, productId = {2}", orderId, new DateTime(purchaseTime), productId), ToastLength.Long).Show();
		}

		private void OnPurchaseFailed()
		{
			Toast.MakeText(this, "PurchaseFailed", ToastLength.Long).Show();
		}
	}
}



