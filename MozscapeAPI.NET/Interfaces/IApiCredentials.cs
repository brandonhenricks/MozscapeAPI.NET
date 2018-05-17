using System;
namespace MozscapeAPI.NET.Interfaces
{
	public interface IApiCredentials
	{
		string AccessId { get; }
		string SecretKey { get; }
		long ExpiresInterval { get; }
	}
}
