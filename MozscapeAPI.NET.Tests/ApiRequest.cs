using System;
using NUnit.Framework;
using MozscapeAPI.NET.Enums;
using MozscapeAPI.NET.Request;
using MozscapeAPI.NET.Interfaces;
using NSubstitute;

namespace MozscapeAPI.NET.Tests
{
	[TestFixture]
	public class ApiRequestTests
	{
		private IApiAuthorization _apiAuthorization;

		[SetUp]
		public void Init()
		{
			_apiAuthorization = Substitute.For<IApiAuthorization>();
		}

		[Test]
		public void ApiRequest_Null_Constructor_Arguments_Throws_Exception()
		{
			Assert.Throws<ArgumentNullException>(() => new ApiRequest(null, null, ApiType.ANCHORTEXT, 0, 0));
		}

		[Test]
		public void ApiRequest_TargetUrl_Argument_Set()
		{
			var apiRequest = new ApiRequest(_apiAuthorization, "http://test.com", ApiType.ANCHORTEXT, 0);

			Assert.AreEqual("http://test.com", apiRequest.TargetUrl);
		}


		[Test]
		public void ApiRequest_ApiType_Argument_Set()
		{
			var apiRequest = new ApiRequest(_apiAuthorization, "http://test.com", ApiType.ANCHORTEXT, 0);

			Assert.AreEqual(ApiType.ANCHORTEXT, apiRequest.ApiType);
		}

		[Test]
		public void ApiRequest_Cols_Argument_Set()
		{
			var apiRequest = new ApiRequest(_apiAuthorization, "http://test.com", ApiType.ANCHORTEXT, 0);

			Assert.AreEqual(0, apiRequest.Cols);
		}

		[Test]
		public void ApiRequest_Limit_Argument_Set()
		{
			var apiRequest = new ApiRequest(_apiAuthorization, "http://test.com", ApiType.ANCHORTEXT, 0, 10);

			Assert.AreEqual(10, apiRequest.Limit);
		}
	}
}
