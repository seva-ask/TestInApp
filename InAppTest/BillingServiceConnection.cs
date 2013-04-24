
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


namespace Omlet.Droid.Classes.BillingV3
{
	public class BillingServiceConnection : Java.Lang.Object, IServiceConnection
	{
		private readonly Action<IInAppBillingService> _serviceConnected;
		private readonly Action _serviceDisconnected;
	
		public BillingServiceConnection(Action<IInAppBillingService> serviceConnected, Action serviceDisconnected)
		{
			_serviceConnected = serviceConnected;
			_serviceDisconnected = serviceDisconnected;
		}

		public void OnServiceConnected(ComponentName name, IBinder service)
		{
			var resultService = IInAppBillingServiceStub.AsInterface(service);
			_serviceConnected(resultService);
		}
		
		public void OnServiceDisconnected(ComponentName name)
		{
			if (_serviceDisconnected != null)
			{
				_serviceDisconnected();
			}
		}
	}
}

