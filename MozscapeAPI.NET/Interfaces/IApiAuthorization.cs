using System;
namespace MozscapeAPI.NET.Interfaces
{
	public interface IApiAuthorization : IApiCredentials
	{
		String GetAuthenticationString();
	}
}
