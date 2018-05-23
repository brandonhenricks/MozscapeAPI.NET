using System;
using MozscapeAPI.NET.Interfaces;
using System.Threading.Tasks;
using EnsureThat;
using MozscapeAPI.NET.Enums;
using MozscapeAPI.NET.Request;
using MozscapeAPI.NET.Authorization;
using RestSharp;
using MozscapeAPI.NET.Services;
using System.Diagnostics.Contracts;
using MozscapeAPI.NET.Constants;
using System.Net;

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

		public IRestClient GetRestClient(IApiRequest apiRequest)
		{
			Ensure.That(apiRequest, nameof(apiRequest)).IsNotNull();

			var endPointUrl = String.Empty;

			switch (apiRequest.ApiType)
			{
				case ApiType.TOP_PAGE:
					endPointUrl = EndPoint + "/" + EndPointConstants.TOP_PAGE;
					break;
				case ApiType.ANCHORTEXT:
					endPointUrl = EndPoint + "/" + EndPointConstants.ANCHOR_TEXT;
					break;
				case ApiType.LINKSCAPE:
					endPointUrl = EndPoint + "/" + EndPointConstants.LINK_SCAPE;
					break;
				case ApiType.URL_METRICS:
					endPointUrl = EndPoint + "/" + EndPointConstants.URL_METRICS;
					break;

			}
			return new RestClient(endPointUrl);
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

		public Task<IRestResponse> GetRestResponseAsync(string targetUrl, IApiRequest apiRequest)
		{
			Ensure.That(targetUrl, nameof(targetUrl)).IsNotNullOrEmpty();
			Ensure.That(apiRequest, nameof(apiRequest)).IsNotNull();
			var restClient = GetRestClient(apiRequest);
			var apiService = new ApiService(apiRequest.Authorization, restClient);

			return apiService.GetResponseAsync(apiRequest);
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
