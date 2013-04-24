using System;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;
using Omlet.Common.API;

namespace Omlet.Droid
{
	public static class IApParametersCalculator
	{
		public static string GetReceiptId(string orderId, long purchaseTime, string productId)
		{
			var jObject = new JObject();
			jObject.Add("orderId", orderId);
			jObject.Add("purchaseTime", purchaseTime);
			jObject.Add("productId", productId);
			jObject.Add("is_sandbox", false);
			return jObject.ToString();
		}

		private const string CLIENT_SECRET = "blablabla";

		// http://dotnetpulse.blogspot.ru/2007/12/sha1-hash-calculation-in-c.html
		// http://stackoverflow.com/questions/1756188/how-to-use-sha1-or-md5-in-cwhich-one-is-better-in-performance-and-security-fo
		// http://msdn.microsoft.com/ru-ru/library/system.security.cryptography.sha1.aspx
		// http://www.tools4noobs.com/online_php_functions/sha1/
		// to be equal to server we do ToLower
		public static string GetSignature(string receiptId)
		{
			string encodedReceiptId = Encoder.EncodeTo64(receiptId);
			string toEncode = encodedReceiptId + CLIENT_SECRET;
			byte[] encodedBytes = Encoder.EncodeToBytes(toEncode);
			var cryptoTransformSHA1 = new SHA1CryptoServiceProvider();
			string result = BitConverter.ToString(cryptoTransformSHA1.ComputeHash(encodedBytes)).Replace("-", "").ToLower();
			return result;
		}
	}
}

