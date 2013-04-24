
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
using System.Security.Cryptography;

namespace Omlet.Droid.Classes.BillingV3
{
	public static class Security
	{
		// http://stackoverflow.com/questions/5605124/android-in-app-billing-verification-of-receipt-in-dot-netc
		// utility for converting keys can be found in repository

		public static bool VerifyDataSignature(string data, string sign, ISecurityKey key)
		{
			using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
			{
				RSAParameters rsaKeyInfo = new RSAParameters() 
				{ 
					Exponent = Convert.FromBase64String(key.PublicKeyExponent), 
					Modulus = Convert.FromBase64String(key.PublicKeyModulus) 
				};
				rsa.ImportParameters(rsaKeyInfo);
				
				return rsa.VerifyData(Encoding.ASCII.GetBytes(data), "SHA1", Convert.FromBase64String(sign));
			}
		}
	}
}

