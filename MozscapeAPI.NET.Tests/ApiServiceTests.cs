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
		public void ApiService_GetResponse_Null_Argument_Throws_Exception()
		{
			var restClient = Substitute.For<IRestClient>();
			var apiAuth = Substitute.For<IApiAuthorization>();
			var apiService = new ApiService(apiAuth, restClient);

			Assert.Throws<ArgumentNullException>(() => apiService.GetResponse(null));
		}

		[Test]
		public void ApiService_GetResponseAsync_Null_Argument_Throws_Exception()
		{
			var restClient = Substitute.For<IRestClient>();
			var apiAuth = Substitute.For<IApiAuthorization>();
			var apiService = new ApiService(apiAuth, restClient);

			Assert.Throws<ArgumentNullException>(() => apiService.GetResponseAsync(null));
		}
	}
}
