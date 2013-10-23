
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

namespace InAppTest
{
	public class OpenAppstoreConnection : Java.Lang.Object, IServiceConnection
	{
		private readonly Action<IOpenAppstore> _serviceConnected;
		private readonly Action _serviceDisconnected;

		public OpenAppstoreConnection(Action<IOpenAppstore> serviceConnected, Action serviceDisconnected)
		{
			_serviceConnected = serviceConnected;
			_serviceDisconnected = serviceDisconnected;
		}

		public void OnServiceConnected(ComponentName name, IBinder service)
		{
			var resultService = IOpenAppstoreStub.AsInterface(service);
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

