using System;
using RestSharp;
using System.Threading.Tasks;
namespace MozscapeAPI.NET.Interfaces
{
	public interface IApiService : IDisposable
	{
		IRestResponse GetResponse(IApiRequest apiRequest);
		Task<IRestResponse> GetResponseAsync(IApiRequest apiRequest);
	}
}
