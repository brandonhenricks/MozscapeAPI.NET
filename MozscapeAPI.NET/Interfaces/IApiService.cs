using System;
using RestSharp;
using System.Threading.Tasks;
namespace MozscapeAPI.NET.Interfaces
{
	public interface IApiService : IDisposable
	{
		IRestResponse GetResponse(String targetUrl);
		Task<IRestResponse> GetResponseAsync(String targetUrl);
	}
}
