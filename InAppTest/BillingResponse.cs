
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

namespace Omlet.Droid.Classes.BillingV3
{
	public class BillingResponse
	{
		public const string ResponseCode = "RESPONSE_CODE";

		public const string RESPONSE_INAPP_ITEM_LIST = "INAPP_PURCHASE_ITEM_LIST";
		public const string RESPONSE_INAPP_PURCHASE_DATA_LIST = "INAPP_PURCHASE_DATA_LIST";
		public const string RESPONSE_INAPP_SIGNATURE_LIST = "INAPP_DATA_SIGNATURE_LIST";

		public const string INAPP_CONTINUATION_TOKEN = "INAPP_CONTINUATION_TOKEN";

		public const string RESPONSE_BUY_INTENT = "BUY_INTENT";

		public const string RESPONSE_INAPP_PURCHASE_DATA = "INAPP_PURCHASE_DATA";
		public const string RESPONSE_INAPP_SIGNATURE = "INAPP_DATA_SIGNATURE";
	}
}

