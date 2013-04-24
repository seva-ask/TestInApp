
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
	public class BillingResponseResult
	{
		public const int OK = 0;
		public const int USER_CANCELED = 1;
		public const int BILLING_UNAVAILABLE = 3;
		public const int ITEM_UNAVAILABLE = 4;
		public const int DEVELOPER_ERROR = 5;
		public const int ERROR = 6;
		public const int ITEM_ALREADY_OWNED = 7;
		public const int ITEM_NOT_OWNED = 8;
	}
}

