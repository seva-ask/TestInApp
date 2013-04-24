
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
	public static class IdGenerator
	{
		private static int _currentId = 1;

		public static int Next()
		{
			return Interlocked.Increment(ref _currentId);
		}
	}
}

