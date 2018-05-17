using System;
using System.Threading.Tasks;

namespace MozscapeAPI.NET.Interfaces
{
	public interface IMozApiClient : IDisposable
	{
		T GetApiResult<T>(String targetUrl);
		Task<T> GetApiResultAsync<T>(String targetUrl);
		String GetQueryString(String targetUrl, int cols);
	}
}
