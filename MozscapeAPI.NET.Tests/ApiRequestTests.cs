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
		public void ApiRequest_Null_Constructor_Argument_Scope_Throws_Exception()
		{
			Assert.Throws<ArgumentNullException>(() => new ApiRequest(_apiAuthorization, "test.com", ApiType.ANCHORTEXT, 0, null, "test"));
		}

		[Test]
		public void ApiRequest_Null_Constructor_Argument_Sort_Throws_Exception()
		{
			Assert.Throws<ArgumentNullException>(() => new ApiRequest(_apiAuthorization, "test.com", ApiType.ANCHORTEXT, 0, "test", null));
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


		[Test]
		public void ApiRequest_GetSafeUrl_Returns_Not_Null()
		{
			var apiRequest = new ApiRequest(_apiAuthorization, "http://test.com", ApiType.ANCHORTEXT, 0, 10);

			Assert.NotNull(apiRequest.GetSafeUrl());
		}

		[Test]
		public void ApiRequest_GetSafeUrl_Returns_Correct_Result()
		{
			var apiRequest = new ApiRequest(_apiAuthorization, "http://test.com", ApiType.ANCHORTEXT, 0, 10);
			var result = apiRequest.GetSafeUrl();
			Assert.AreEqual("test.com", result);
		}

		[Test]
		public void ApiRequest_GetSafeUrl_With_SubPage_Returns_Correct_Result()
		{
			var apiRequest = new ApiRequest(_apiAuthorization, "http://test.com/test", ApiType.ANCHORTEXT, 0, 10);
			var result = apiRequest.GetSafeUrl();
			Assert.AreNotEqual("test.com", result);
		}
	}
}
