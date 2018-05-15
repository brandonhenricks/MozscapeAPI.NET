using System;
using MozscapeAPI.NET.Interfaces;
using RestSharp;
namespace MozscapeAPI.NET
{
	public class MozApiClient : IMozApiClient, IDisposable
	{
		private readonly IApiAuthorization _apiAuthorization;
		private readonly IRestClient _restClient;
		private readonly String _endPoint;

		public MozApiClient(IApiAuthorization apiAuthorization, string endPoint)
		{
			_apiAuthorization = apiAuthorization ?? throw new ArgumentNullException(nameof(apiAuthorization), "apiAuthorization can not be null");

			if (string.IsNullOrEmpty(endPoint))
			{
				throw new ArgumentNullException(nameof(endPoint));
			}
			_endPoint = endPoint;
			_restClient = new RestClient(endPoint);
		}

		public T GetApiResult<T>(String targetUrl)
		{
			var request = new RestRequest(targetUrl, Method.GET);

			var result = _restClient.Execute(request);

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
