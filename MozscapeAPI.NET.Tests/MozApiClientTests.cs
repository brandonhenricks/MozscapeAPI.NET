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
	}
}
