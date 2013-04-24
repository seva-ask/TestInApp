
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
	public interface ISecurityKey
	{
		string PublicKeyExponent { get; }
		
		string PublicKeyModulus { get; }
	}
}

