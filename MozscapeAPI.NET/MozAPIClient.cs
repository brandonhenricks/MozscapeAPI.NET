using System;
using MozscapeAPI.NET.Interfaces;
using System.Threading.Tasks;
using EnsureThat;
using MozscapeAPI.NET.Enums;
using MozscapeAPI.NET.Request;
using MozscapeAPI.NET.Authorization;

namespace MozscapeAPI.NET
{
	public class MozApiClient : IMozApiClient
	{
		#region Public Properties

		public string AccessId { get; }
		public string SecretKey { get; }
		public long ExpiresInterval { get; }
		public string EndPoint { get; }

		#endregion

		#region Public Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="T:MozscapeAPI.NET.MozApiClient"/> class.
		/// </summary>
		/// <param name="accessId">Access identifier.</param>
		/// <param name="secretKey">Secret key.</param>
		/// <param name="expiresInterval">Expires interval.</param>
		/// <param name="endPoint">End point.</param>
		public MozApiClient(string accessId, string secretKey, long expiresInterval, string endPoint)
		{
			Ensure.That(accessId, nameof(accessId)).IsNotNullOrEmpty();
			Ensure.That(secretKey, nameof(secretKey)).IsNotNullOrEmpty();
			Ensure.That(expiresInterval, nameof(expiresInterval)).IsGt(0);
			Ensure.That(endPoint, nameof(endPoint)).IsNotNullOrEmpty();

			AccessId = accessId;
			SecretKey = secretKey;
			ExpiresInterval = expiresInterval;
			EndPoint = endPoint;
		}

		#endregion

		public T GetApiResult<T>(String targetUrl)
		{
			Ensure.That(targetUrl, nameof(targetUrl)).IsNotNullOrEmpty();

			throw new NotImplementedException();
		}

		public Task<T> GetApiResultAsync<T>(string targetUrl)
		{
			Ensure.That(targetUrl, nameof(targetUrl)).IsNotNullOrEmpty();
			throw new NotImplementedException();
		}

		public IApiAuthorization GetApiAuthorization()
		{
			return new ApiAuthorization(AccessId, SecretKey, ExpiresInterval);
		}

		public IApiRequest CreateApiRequest(IApiAuthorization apiAuthorization, string targetUrl, ApiType apiType, int cols, int limit)
		{
			return new ApiRequest(apiAuthorization, targetUrl, apiType, cols, limit);
		}

		public IApiRequest CreateApiRequest(IApiAuthorization apiAuthorization, string targetUrl, ApiType apiType, int cols, int limit, string scope, string filter)
		{
			return new ApiRequest(apiAuthorization, targetUrl, apiType, cols, limit);
		}

		#region IDisposable Support
		private bool disposedValue = false; // To detect redundant calls

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					// TODO: dispose managed state (managed objects).
					//_apiService.Dispose();
				}

				// TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
				// TODO: set large fields to null.

				disposedValue = true;
			}
		}

		// TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
		// ~MozApiClient() {
		//   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
		//   Dispose(false);
		// }

		// This code added to correctly implement the disposable pattern.
		public void Dispose()
		{
			// Do not change this code. Put cleanup code in Dispose(bool disposing) above.
			Dispose(true);
			// TODO: uncomment the following line if the finalizer is overridden above.
			// GC.SuppressFinalize(this);
		}

		#endregion
	}
}
