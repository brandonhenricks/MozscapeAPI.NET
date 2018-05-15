using System;
using MozscapeAPI.NET.Services;
using NUnit.Framework;
using NUnit.Framework.Internal;
using NSubstitute;
using RestSharp;
using MozscapeAPI.NET.Interfaces;

namespace MozscapeAPI.NET.Tests
{
	[TestFixture]
	public class ApiServiceTests
	{
		[Test]
		public void ApiService_Null_Constructor_Arguments_Throws_Exception()
		{
			Assert.Throws<ArgumentNullException>(() => new ApiService(null, null));
		}

		[Test]
		public void ApiService_Constructor_Null_ApiAuthorization_Throws_Exception()
		{
			var restClient = Substitute.For<IRestClient>();
			Assert.Throws<ArgumentNullException>(() => new ApiService(null, restClient));
		}

		[Test]
		public void ApiService_Constructor_Null_RestClient_Throws_exception()
		{
			var apiAuth = Substitute.For<IApiAuthorization>();
			Assert.Throws<ArgumentNullException>(() => new MozApiClient(apiAuth, null));
		}
	}
}
