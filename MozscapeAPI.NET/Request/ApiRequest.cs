﻿using System;
using EnsureThat;
using MozscapeAPI.NET.Enums;
using MozscapeAPI.NET.Interfaces;
namespace MozscapeAPI.NET.Request
{
	public class ApiRequest : IApiRequest
	{
		public IApiAuthorization Authorization { get; }
		public string TargetUrl { get; }
		public ApiType ApiType { get; }
		public int Cols { get; }
		public int Limit { get; }

		#region Public Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="T:MozscapeAPI.NET.Request.ApiRequest"/> class.
		/// </summary>
		/// <param name="apiAuthorization">API authorization.</param>
		/// <param name="targetUrl">Target URL.</param>
		/// <param name="apiType">API type.</param>
		/// <param name="cols">Cols.</param>
		/// <param name="limit">Limit.</param>
		public ApiRequest(IApiAuthorization apiAuthorization, string targetUrl, ApiType apiType, int cols, int limit)
		{
			Ensure.That(targetUrl, nameof(targetUrl)).IsNotNullOrEmpty();
			Ensure.That(apiAuthorization, nameof(apiAuthorization)).IsNotNull();
			Authorization = apiAuthorization;
			TargetUrl = targetUrl;
			ApiType = apiType;
			Cols = cols;
			Limit = limit;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:MozscapeAPI.NET.Request.ApiRequest"/> class.
		/// </summary>
		/// <param name="apiAuthorization">API authorization.</param>
		/// <param name="targetUrl">Target URL.</param>
		/// <param name="apiType">API type.</param>
		/// <param name="cols">Cols.</param>
		public ApiRequest(IApiAuthorization apiAuthorization, string targetUrl, ApiType apiType, int cols)
		{
			Ensure.That(targetUrl, nameof(targetUrl)).IsNotNullOrEmpty();
			Ensure.That(apiAuthorization, nameof(apiAuthorization)).IsNotNull();
			Authorization = apiAuthorization;
			TargetUrl = targetUrl;
			ApiType = apiType;
			Cols = cols;
			Limit = 0;
		}

		#endregion

		/// <summary>
		/// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:MozscapeAPI.NET.Request.ApiRequest"/>.
		/// </summary>
		/// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:MozscapeAPI.NET.Request.ApiRequest"/>.</returns>
		public override string ToString()
		{
			if (Limit > 0)
			{
				return String.Format("?{0}&cols={1}&limit={2}&{3}", TargetUrl, Cols, Limit, Authorization.GetAuthenticationString());
			}
			return String.Format("?{0}&cols={1}&{2}", TargetUrl, Cols, Authorization.GetAuthenticationString());
		}
	}
}