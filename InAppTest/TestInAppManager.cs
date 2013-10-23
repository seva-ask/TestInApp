using System;

using Android.App;
using Android.Content;
using Android.Widget;
using Omlet.Droid.Classes.BillingV3;
using Omlet.Droid.Classes;

namespace InAppTest
{
	public class TestInAppManager
	{
		private InAppHelper InAppHelper{ get; set;}
		private Activity Activity{get; set;}

		private string TravaSubscriptionId 
		{
			
//#if DEBUG
//			get { return "android.test.purchased"; }
//#else
			get { return "test.test.tt"; }
//#endif
			
		}

		
		public TestInAppManager (Activity activity)
		{
			Activity = activity;
		}

		public void StartPurchase()
		{
			if (InAppHelper == null)
			{
				InAppHelper = new InAppHelper(TravaSecureKey.Instance, Activity);
				InAppHelper.Initialize(() => BuyItem(TravaSubscriptionId, PurchaseItemType.InApp));
			}
			else
			{
				BuyItem(TravaSubscriptionId, PurchaseItemType.InApp);
			}
		}

		void BuyItem(string productId, PurchaseItemType itemType)
		{
			if(InAppHelper.PurchasesEnabled)
			{
				InAppHelper.StartPurchase(TravaSubscriptionId ,PurchaseItemType.InApp, string.Empty, true);
			}
			else
			{
				Activity.RunOnUiThread(() => Toast.MakeText(Activity, "Purchases is not available", ToastLength.Long));
			}
		}
		

		
		public void Dispose()
		{
			InAppHelper.Dispose ();
		}
		
		public Purchase GetPurchaseFromActivityResult(int requestCode, Result result, Intent data)
		{
			return InAppHelper.GetPurchaseFromActivityResult (requestCode, result, data);
		}

		class TravaSecureKey : ISecurityKey // Panic panic panic
		{
			private TravaSecureKey()
			{}
			
			public static TravaSecureKey Instance = new TravaSecureKey();
			
			public string PublicKeyExponent
			{
				get { return "AQAB"; }
			}			
			public string PublicKeyModulus
			{
				get 
				{ 
					return "ov3Y01uFG8LevMabu0q5R+KyaOt8Qf1JyPuVbVOykW78MLJyD0f7Zleox+zjGpZ4dhDmsVwKd9d" +
						"BgKJSo0wuaws6zOXyonbYr4FE9LTW9CebBHK6akQs1YdXPfrn50DeG7th6qxTs8DdSFjkrSz31nPaZiZ1XXn3" +
							"anS6S+f/DsDSVv3d7Jl+cMG7l50v7jaVr7eWX/TAMeaixWbmBaUlUImkOMCcH8tuy2brRDyYov5axawniT5B" +
							"d069fMKcihaLw3hPrFOG3D6Pzf44udiTQjPz/S8Y8ne1bcEZQrdzqhjtST/sXpMMm8joph+x2UAtw+Lo6w3y" +
							"spzsFsyscid4XQ==";
				}
			}
		}
	}
}

