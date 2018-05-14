using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MozscapeAPI.NET.Interfaces
{
	public interface IBaseService : IDisposable
	{
		T GetResult<T>(string targetUrl);
		Task<T> GetResultAsync<T>(string targetUrl);
	}
}
