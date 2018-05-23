using System;
using System.Threading.Tasks;
using MozscapeAPI.NET.Enums;
using RestSharp;

namespace MozscapeAPI.NET.Interfaces
{
	public interface IMozApiClient : IApiCredentials, IDisposable
	{
		string EndPoint { get; }

		Task<IRestResponse> GetRestResponseAsync(String targetUrl, IApiRequest apiRequest);
		IApiAuthorization GetApiAuthorization();

		IRestClient GetRestClient(IApiRequest apiRequest);
		IApiRequest CreateApiRequest(IApiAuthorization apiAuthorization, String targetUrl, ApiType apiType, int cols, int limit = 0);
		IApiRequest CreateApiRequest(IApiAuthorization apiAuthorization, String targetUrl, ApiType apiType, int cols, int limit, string scope, string sort);
	}
}
