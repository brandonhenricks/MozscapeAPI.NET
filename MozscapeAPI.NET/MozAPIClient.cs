using System;
using MozscapeAPI.NET.Interfaces;
using RestSharp;
using MozscapeAPI.NET.Services;
namespace MozscapeAPI.NET
{
	public class MozApiClient : IMozApiClient
	{
		private readonly String _endPoint;
		private readonly IApiService _apiService;

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

		public T GetApiResult<T>(String targetUrl)
		{
			var request = new RestRequest(targetUrl, Method.GET);

			//var result = _restClient.Execute(request);

			throw new NotImplementedException();
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
