using System;
using System.Text;
using System.Net;

namespace MozscapeAPI.NET
{
	public class ApiAuthorization
	{
		public string AccessId { get; private set; }
		public string SecretKey { get; private set; }
		public long ExpiresInterval { get; private set; }

		public ApiAuthorization(string accessId, string secretKey, long expires)
		{
			if (string.IsNullOrEmpty(accessId))
			{
				throw new ArgumentNullException("accessId can not be null");
			}

			if (string.IsNullOrEmpty(secretKey))
			{
				throw new ArgumentNullException("secretKey can not be null");
			}

			AccessId = accessId;
			SecretKey = secretKey;
			ExpiresInterval = expires;
		}

		public string GetAuthenticationString()
		{
			long expires = ((new DateTime().Millisecond) / 1000 + ExpiresInterval);

			string stringToSign = AccessId + "\n" + expires;

			string authSignature = GenerateSignature(SecretKey, stringToSign);

			string urlSafeSignature = WebUtility.UrlEncode(authSignature);

			return String.Format("AccessID={0}&Expires={1}&Signature={2}", AccessId, expires, urlSafeSignature);
		}

		private string GenerateSignature(string key, string content)
		{
			var hmac = new System.Security.Cryptography.HMACSHA1
			{
				Key = Encoding.UTF8.GetBytes(key)
			};

			var contentBytes = Encoding.UTF8.GetBytes(content);
			var signature = hmac.ComputeHash(contentBytes);
			return Convert.ToBase64String(signature);
		}
	}
}
