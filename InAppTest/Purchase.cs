
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
using Newtonsoft.Json.Linq;

namespace Omlet.Droid.Classes.BillingV3
{
	public class Purchase
	{
		public PurchaseItemType ItemType { get; private set; }

		public string Signature { get; private set; }


		public string OrderId { get; private set; }

		public string ProductId { get; private set; }

		public long PurchaseTime { get; private set; }

		public string Token { get; private set; }


		public Purchase(PurchaseItemType itemType, string jsonPurchaseInfo, string signature)
		{
			ItemType = itemType;
			Signature = signature;

			var json = JObject.Parse(jsonPurchaseInfo) as JObject;
		
			OrderId = (string) json["orderId"];
			ProductId = (string) json["productId"];
			PurchaseTime = (long) json["purchaseTime"];

//			mPackageName = o.optString("packageName");
//			mDeveloperPayload = o.optString("developerPayload");
//			mPurchaseState = o.optInt("purchaseState");

			JToken tokenToken;
			if (!json.TryGetValue("token", out tokenToken))
			{
				tokenToken = json["purchaseToken"];
			}
			Token = (string) tokenToken;
		}
	}
}
