using System;
namespace MozscapeAPI.NET.Interfaces
{
	public interface IMozApiClient : IDisposable
	{
		T GetApiResult<T>(String targetUrl);
	}
}
