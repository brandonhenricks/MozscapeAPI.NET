using System;
using MozscapeAPI.NET.Enums;

namespace MozscapeAPI.NET.Interfaces
{
	public interface IApiRequest
	{
		String TargetUrl { get; }
		ApiType ApiType { get; }
		int Cols { get; }
		int Limit { get; }
	}
}
