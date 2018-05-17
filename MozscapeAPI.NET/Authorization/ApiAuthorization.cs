using System;
using System.Net;
using System.Text;
using EnsureThat;
using MozscapeAPI.NET.Interfaces;

namespace MozscapeAPI.NET.Authorization
{
	public class ApiAuthorization : IApiAuthorization
	{
		#region Public Properties
		public string AccessId { get; }
		public string SecretKey { get; }
		public long ExpiresInterval { get; }
		#endregion

		#region Constructors
		public ApiAuthorization(string accessId, string secretKey, long expiresInterval)
		{
			Ensure.That(accessId).IsNotNullOrEmpty();
			Ensure.That(secretKey).IsNotNullOrEmpty();
			AccessId = accessId;
			SecretKey = secretKey;
			ExpiresInterval = expiresInterval;
		}
		#endregion

		#region Public Methods
		public string GetAuthenticationString()
		{
			long expires = ((new DateTime().Millisecond) / 1000 + ExpiresInterval);

			string stringToSign = AccessId + "\n" + expires;

			string authSignature = GenerateSignature(SecretKey, stringToSign);

			string urlSafeSignature = WebUtility.UrlEncode(authSignature);

			return String.Format("AccessID={0}&Expires={1}&Signature={2}", AccessId, expires, urlSafeSignature);
		}
		#endregion

		#region Private Methods
		private string GenerateSignature(string key, string content)
		{
			Ensure.That(key).IsNotNullOrEmpty();
			Ensure.That(content).IsNotNullOrEmpty();

			var hmac = new System.Security.Cryptography.HMACSHA1
			{
				Key = Encoding.UTF8.GetBytes(key)
			};

			try
			{
				var signature = hmac.ComputeHash(Encoding.UTF8.GetBytes(content));

				return Convert.ToBase64String(signature);
			}
			catch (Exception ex) //TODO: Catch Specific Exception
			{
				throw ex;
			}
		}
		#endregion
	}
}
