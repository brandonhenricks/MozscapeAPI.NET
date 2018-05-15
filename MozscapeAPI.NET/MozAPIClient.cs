using System;
using MozscapeAPI.NET.Interfaces;
namespace MozscapeAPI.NET
{
	public class MozApiClient : IMozApiClient
	{
		private readonly IApiAuthorization _apiAuthorization;

		public MozApiClient()
		{
		}

		public MozApiClient(IApiAuthorization apiAuthorization)
		{

		}

		public void Dispose()
		{
			throw new NotImplementedException();
		}
	}
}
