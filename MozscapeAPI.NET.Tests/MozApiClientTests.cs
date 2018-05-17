using System;
using NUnit.Framework;
using MozscapeAPI.NET.Interfaces;
using NSubstitute.Exceptions;
using NSubstitute;
using System.Xml.Linq;

namespace MozscapeAPI.NET.Tests
{
	[TestFixture]
	public class MozApiClientTests
	{
		private IMozApiClient _mozApiclient;

		[SetUp]
		public void Init()
		{
			_mozApiclient = Substitute.For<IMozApiClient>();
		}

		[Test]
		public void MozApiClient_Null_Constructor_Arguments_Throws_Exception()
		{
			Assert.Throws<ArgumentNullException>(() => new MozApiClient(null, null));
		}

		[Test]
		public void MozApiClient_Constructor_Null_ApiAuthorization_Throws_Exception()
		{
			Assert.Throws<ArgumentNullException>(() => new MozApiClient(null, "https://test.com"));
		}

		[Test]
		public void MozApiClient_Constructor_Null_Endpoint_Throws_Exception()
		{
			var apiAuth = Substitute.For<IApiAuthorization>();
			Assert.Throws<ArgumentNullException>(() => new MozApiClient(apiAuth, null));
		}

		[Test]
		public void MozApiClient_GetQuery_String_Null_Param_Throws_Exception()
		{
			var apiAuth = Substitute.For<IApiAuthorization>();
			var apiClient = new MozApiClient(apiAuth, "http://test.com");
			Assert.Throws<ArgumentNullException>(() => apiClient.GetQueryString(null, 0));
		}
	}
}
