using System;
namespace MozscapeAPI.NET.Interfaces
{
	public interface IApiAuthorization
	{
		string AccessId { get; }
		string SecretKey { get; }
		long ExpiresInterval { get; }
		String GetAuthenticationString();
	}
}
