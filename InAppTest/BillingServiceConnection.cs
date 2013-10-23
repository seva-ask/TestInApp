
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
using Org.Onepf.Oms;


namespace Omlet.Droid.Classes.BillingV3
{
	public class BillingServiceConnection : Java.Lang.Object, IServiceConnection
	{
		private readonly Action<IOpenInAppBillingService> _serviceConnected;
		private readonly Action _serviceDisconnected;
	
		public BillingServiceConnection(Action<IOpenInAppBillingService> serviceConnected, Action serviceDisconnected)
		{
			_serviceConnected = serviceConnected;
			_serviceDisconnected = serviceDisconnected;
		}

		public void OnServiceConnected(ComponentName name, IBinder service)
		{
			var resultService = IOpenInAppBillingServiceStub.AsInterface(service);
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

