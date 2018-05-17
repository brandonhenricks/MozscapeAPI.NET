using System;
using System.Threading.Tasks;
using MozscapeAPI.NET.Enums;

namespace MozscapeAPI.NET.Interfaces
{
	public interface IMozApiClient : IDisposable
	{
		string AccessId { get; }
		string SecretKey { get; }
		long ExpiresInterval { get; }
		string EndPoint { get; }
		T GetApiResult<T>(String targetUrl);
		Task<T> GetApiResultAsync<T>(String targetUrl);
		IApiAuthorization GetApiAuthorization();
		IApiRequest CreateApiRequest(IApiAuthorization apiAuthorization, String targetUrl, ApiType apiType, int cols, int limit);
	}
}
