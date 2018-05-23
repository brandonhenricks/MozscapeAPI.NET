using System;
using EnsureThat;
using MozscapeAPI.NET.Enums;
using MozscapeAPI.NET.Interfaces;
using System.Net;
using System.Text;
namespace MozscapeAPI.NET.Request
{
	public class ApiRequest : IApiRequest
	{
		#region Public Properties
		public IApiAuthorization Authorization { get; }
		public string TargetUrl { get; }
		public ApiType ApiType { get; }
		public int Cols { get; }
		public int Limit { get; }
		public string Scope { get; }
		public string Sort { get; }
		#endregion

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

		/// <summary>
		/// Initializes a new instance of the <see cref="T:MozscapeAPI.NET.Request.ApiRequest"/> class.
		/// </summary>
		/// <param name="apiAuthorization">API authorization.</param>
		/// <param name="targetUrl">Target URL.</param>
		/// <param name="apiType">API type.</param>
		/// <param name="cols">Cols.</param>
		/// <param name="scope">Scope.</param>
		/// <param name="sort">Sort.</param>
		public ApiRequest(IApiAuthorization apiAuthorization, string targetUrl, ApiType apiType, int cols, string scope, string sort)
		{
			Ensure.That(targetUrl, nameof(targetUrl)).IsNotNullOrEmpty();
			Ensure.That(apiAuthorization, nameof(apiAuthorization)).IsNotNull();
			Ensure.That(scope, nameof(scope)).IsNotNullOrEmpty();
			Ensure.That(sort, nameof(sort)).IsNotNullOrEmpty();
			Authorization = apiAuthorization;
			TargetUrl = targetUrl;
			ApiType = apiType;
			Cols = cols;
			Limit = 0;
			Scope = scope;
			Sort = sort;
		}

		#endregion

		#region Public Methods
		/// <summary>
		/// Gets the safe URL.
		/// </summary>
		/// <returns>The safe URL.</returns>
		public string GetSafeUrl()
		{
			var uri = new Uri(TargetUrl);
			if (uri.LocalPath.Length > 1)
			{
				return WebUtility.UrlEncode(String.Format("{0}{1}", uri.Host, uri.LocalPath));
			}
			return uri.Host;
		}

		/// <summary>
		/// Gets the request URL.
		/// </summary>
		/// <returns>The request URL.</returns>
		public string GetRequestUrl()
		{
			var sb = new StringBuilder();
			sb.Append("?" + GetSafeUrl());
			sb.Append("&Cols=" + Cols);

			if (String.IsNullOrEmpty(Scope))
			{
				sb.Append("&Scope=" + Scope);
			}

			if (String.IsNullOrEmpty(Sort))
			{
				sb.Append("&Sort=" + Sort);
			}

			if (Limit > 0)
			{
				sb.Append("&Limit=" + Limit);
			}
			return String.Format("{0}&{1}", sb.ToString(), Authorization.GetAuthenticationString());
		}
		#endregion

		/// <summary>
		/// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:MozscapeAPI.NET.Request.ApiRequest"/>.
		/// </summary>
		/// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:MozscapeAPI.NET.Request.ApiRequest"/>.</returns>
		public override string ToString()
		{
			return GetRequestUrl();
		}

	}
}
