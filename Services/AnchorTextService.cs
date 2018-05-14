using System;
using System.Net.Http;
using System.Threading.Tasks;
using MozscapeAPI.NET.Interfaces;

namespace MozscapeAPI.NET.Services
{
	public class AnchorTextService : IAnchorTextService
	{
		private readonly ApiAuthorization _apiAuthorization;

		public AnchorTextService(ApiAuthorization apiAuthorization)
		{
			_apiAuthorization = apiAuthorization ?? throw new ArgumentNullException(nameof(apiAuthorization), "apiAuthorization can not be null");
		}

		public T GetResult<T>(string targetUrl)
		{
			throw new NotImplementedException();
		}

		public Task<T> GetResultAsync<T>(string targetUrl)
		{
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
		// ~AnchorTextService() {
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
