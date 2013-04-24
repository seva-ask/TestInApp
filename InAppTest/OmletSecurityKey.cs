
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
using Omlet.Droid.Classes.BillingV3;

namespace Omlet.Droid.Classes
{
	public class OmletSecurityKey : ISecurityKey
	{
		public string PublicKeyExponent
		{
			get
			{
				return "AQAB";
			}
		}
		
		public string PublicKeyModulus
		{
			get
			{
				return "hmOipwolnlhPL/7Pb+fQh0/wiOcYCgdin1kNOk/aFiSyMJXCPx/ym7coiremQ88FZA93NWR1OLxZZTskQrOTYiLQ0gqSgsKjWqburwZIqJDkQSSpjFv+iizwJ3tD/9u5imItyVVKjjuMedFSKjzFKANg681CYCjUeZS7NmAwk/RTm/UJgw1PjKMR4A/KU8Zhrr20xSQbPZh+Mdel0sSBYiKe9o/knzGBL5RnC3KfFT5xaZRjJVbHXlx9XAta0ZSwBO0ksO1jEblOULr2I1GaOaWLi7OtLUR/l+1IaKCzCUR6G6yHeAzSX8inyf2kEHlzBuKg+Dl3XdK7VJGUV5ywwQ==";
			}
		}
	}
}

