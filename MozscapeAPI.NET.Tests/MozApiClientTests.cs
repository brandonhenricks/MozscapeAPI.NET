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
			Assert.Throws<ArgumentNullException>(() => new MozApiClient(null, null, 1, null));
		}

		[Test]
		public void MozApiClient_Constructor_Null_AccessId_Throws_Exception()
		{
			Assert.Throws<ArgumentNullException>(() => new MozApiClient(null, null, 1, "https://test.com"));
		}

		[Test]
		public void MozApiClient_Constructor_Null_SecretKey_Throws_Exception()
		{
			var apiAuth = Substitute.For<IApiAuthorization>();
			Assert.Throws<ArgumentNullException>(() => new MozApiClient("test", null, 1, "https://test.com"));
		}

		[Test]
		public void MozApiClient_CreateApiRequest_Null_Param_Throws_Exception()
		{
			var apiAuth = Substitute.For<IApiAuthorization>();
			var apiClient = new MozApiClient("test", "test", 1, "http://test.com");
			Assert.Throws<ArgumentNullException>(() => apiClient.CreateApiRequest(apiAuth, null, Enums.ApiType.ANCHORTEXT, 0, 0));
		}

		[Test]
		public void MozApiClient_GetApiAuthorization_Returns_Class()
		{
			var apiClient = new MozApiClient("test", "test", 1, "http://test.com");
			var apiAuth = apiClient.GetApiAuthorization();
			Assert.NotNull(apiAuth);

		}
	}
}
