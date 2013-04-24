
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
using System.ComponentModel;

namespace Omlet.Droid.Classes.BillingV3
{
	public class PurchaseItemType
	{
		public static readonly PurchaseItemType InApp = new PurchaseItemType("inapp");

		public static readonly PurchaseItemType Subscription = new PurchaseItemType("subs");

		private string _itemType;

		private PurchaseItemType(string itemtype)
		{
			_itemType = itemtype;
		}

		public static explicit operator string(PurchaseItemType purchaseItemType)
		{
			return purchaseItemType._itemType;
		}
	}
}

