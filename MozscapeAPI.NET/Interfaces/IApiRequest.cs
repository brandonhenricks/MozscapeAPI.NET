using System;
using MozscapeAPI.NET.Enums;

namespace MozscapeAPI.NET.Interfaces
{
	public interface IApiRequest
	{
		IApiAuthorization Authorization { get; }
		string TargetUrl { get; }
		ApiType ApiType { get; }
		int Cols { get; }
		int Limit { get; }
		string Scope { get; }
		string Sort { get; }
		string GetSafeUrl();
		string GetRequestUrl();
	}
}
