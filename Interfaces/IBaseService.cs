using System;
using System.Collections.Generic;

namespace MozscapeAPI.NET.Interfaces
{
	public interface IBaseService : IDisposable
	{
		T GetResult<T>(ApiAuthorization apiAuthorization, string targetUrl);
	}
}
