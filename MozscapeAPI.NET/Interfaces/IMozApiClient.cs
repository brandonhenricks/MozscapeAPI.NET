using System;
using System.Threading.Tasks;
using MozscapeAPI.NET.Enums;

namespace MozscapeAPI.NET.Interfaces
{
	public interface IMozApiClient : IDisposable
	{
		T GetApiResult<T>(String targetUrl);
		Task<T> GetApiResultAsync<T>(String targetUrl);
		IApiRequest CreateApiRequest(IApiAuthorization apiAuthorization, String targetUrl, ApiType apiType, int cols, int limit);
	}
}
