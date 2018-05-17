using System;
using System.Threading.Tasks;
using MozscapeAPI.NET.Enums;

namespace MozscapeAPI.NET.Interfaces
{
	public interface IMozApiClient : IApiCredentials, IDisposable
	{
		string EndPoint { get; }
		T GetApiResult<T>(String targetUrl);
		Task<T> GetApiResultAsync<T>(String targetUrl);
		IApiAuthorization GetApiAuthorization();
		IApiRequest CreateApiRequest(IApiAuthorization apiAuthorization, String targetUrl, ApiType apiType, int cols, int limit = 0);
		IApiRequest CreateApiRequest(IApiAuthorization apiAuthorization, String targetUrl, ApiType apiType, int cols, int limit, string scope, string sort);
	}
}
