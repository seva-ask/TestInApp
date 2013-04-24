using System;
using System.Text;
using Newtonsoft.Json.Linq;


namespace Omlet.Common.API
{
	public static class Encoder
	{
		public static byte[] EncodeToBytes(string str)
		{
			return Encoding.UTF8.GetBytes(str);
		}
		
		public static string EncodeToString(byte[] bytes)
		{
			return Encoding.UTF8.GetString(bytes);
		}
		
		public static string EncodeTo64(byte[] toEncodeAsBytes)
		{
			//TODO
			#if !WP7
			return Convert.ToBase64String(toEncodeAsBytes);
			#else
			throw new NotImplementedException("Not avalilable in WP7");
			#endif
		}
		
		public static string EncodeTo64(JObject jObject)
		{
			return EncodeTo64(jObject.ToString());
		}
		
		public static string EncodeTo64(string str)
		{
			byte[] toEncodeAsBytes = EncodeToBytes(str);
			return EncodeTo64(toEncodeAsBytes);
		}
		
		public static string UrlEncode(string s)
		{ 
			var sb = new StringBuilder();
			
			foreach (byte i in Encoding.UTF8.GetBytes(s))
			{
				if ((i >= 'A' && i <= 'Z') ||
				    (i >= 'a' && i <= 'z') ||
				    (i >= '0' && i <= '9') ||
				    i == '-' || i == '_')
				{
					sb.Append((char)i);
				}
				else if (i == ' ')
				{
					sb.Append('+');
				}
				else
				{
					sb.Append('%');
					sb.Append(i.ToString("X2"));
				}
			}
			
			return sb.ToString();
		}
		
		
	}
}

