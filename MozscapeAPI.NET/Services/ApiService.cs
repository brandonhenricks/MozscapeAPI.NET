using System;
using System.Threading.Tasks;
using EnsureThat;
using MozscapeAPI.NET.Interfaces;
using RestSharp;

namespace MozscapeAPI.NET.Services
{
	public class ApiService : IApiService
	{
		private readonly IApiAuthorization _apiAuthorization;
		private readonly IRestClient _restClient;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="apiAuthorization">API authorization.</param>
		/// <param name="restClient">Rest client.</param>
		public ApiService(IApiAuthorization apiAuthorization, IRestClient restClient)
		{
			_apiAuthorization = apiAuthorization ?? throw new ArgumentNullException(nameof(apiAuthorization));
			_restClient = restClient ?? throw new ArgumentNullException(nameof(restClient));
		}

		/// <summary>
		/// Gets the response.
		/// </summary>
		/// <returns>The response.</returns>
		/// <param name="apiRequest">API request.</param>
		public IRestResponse GetResponse(IApiRequest apiRequest)
		{
			Ensure.That(apiRequest, nameof(apiRequest)).IsNotNull();

			var restRequest = new RestRequest(apiRequest.TargetUrl, Method.GET);

			return _restClient.Execute(restRequest);
		}

		/// <summary>
		/// Gets the response async.
		/// </summary>
		/// <returns>The response async.</returns>
		/// <param name="apiRequest">API request.</param>
		public Task<IRestResponse> GetResponseAsync(IApiRequest apiRequest)
		{
			Ensure.That(apiRequest, nameof(apiRequest)).IsNotNull();
			var restRequest = new RestRequest(apiRequest.TargetUrl, Method.GET);

			return _restClient.ExecuteGetTaskAsync(restRequest);
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
				}

				// TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
				// TODO: set large fields to null.

				disposedValue = true;
			}
		}

		// TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
		// ~ApiService() {
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
