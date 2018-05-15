using System;
namespace MozscapeAPI.NET.Interfaces
{
	public interface IApiAuthorization
	{
		String AccessId { get; }
		String SecretKey { get; }
		long ExpiresInterval { get; }
		String GetAuthenticationString();
	}
}
