using System;
using MozscapeAPI.NET.Interfaces;
using RestSharp;
using MozscapeAPI.NET.Services;
using System.Threading.Tasks;
using EnsureThat;
using MozscapeAPI.NET.Enums;
using MozscapeAPI.NET.Request;

namespace MozscapeAPI.NET
{
	public class MozApiClient : IMozApiClient
	{
		private readonly String _endPoint;
		private readonly IApiService _apiService;

		#region Constructor

		/// <summary>
		/// Initializes a new instance of the <see cref="T:MozscapeAPI.NET.MozApiClient"/> class.
		/// </summary>
		/// <param name="apiAuthorization">API authorization.</param>
		/// <param name="endPoint">End point.</param>
		public MozApiClient(IApiAuthorization apiAuthorization, string endPoint)
		{
			if (apiAuthorization == null)
			{
				throw new ArgumentNullException(nameof(apiAuthorization));
			}

			if (string.IsNullOrEmpty(endPoint))
			{
				throw new ArgumentNullException(nameof(endPoint));
			}

			_endPoint = endPoint;

			_apiService = new ApiService(apiAuthorization, new RestClient(endPoint));
		}
		#endregion

		public T GetApiResult<T>(String targetUrl)
		{
			Ensure.That(targetUrl, nameof(targetUrl)).IsNotNullOrEmpty();

			var request = _apiService.GetResponse(targetUrl);

			throw new NotImplementedException();
		}

		public Task<T> GetApiResultAsync<T>(string targetUrl)
		{
			Ensure.That(targetUrl, nameof(targetUrl)).IsNotNullOrEmpty();
			var request = _apiService.GetResponseAsync(targetUrl);
			throw new NotImplementedException();
		}

		public IApiRequest CreateApiRequest(string targetUrl, ApiType apiType, int cols, int limit)
		{
			return new ApiRequest(targetUrl, apiType, cols, limit);
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
					_apiService.Dispose();
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
