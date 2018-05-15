using System;
namespace MozscapeAPI.NET.Interfaces
{
	public interface IMozApiClient
	{
		T GetApiResult<T>(String targetUrl);
	}
}
