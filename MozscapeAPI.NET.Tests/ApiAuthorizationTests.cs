﻿using System;
using NUnit.Framework;
using MozscapeAPI.NET.Authorization;

namespace MozscapeAPI.NET.Tests
{
	[TestFixture]
	public class ApiAuthorizationTests
	{
		[Test]
		public void ApiAuthorization_Null_Constructor_Arguments_Throws_Exception()
		{
			Assert.Throws<ArgumentNullException>(() => new ApiAuthorization(null, null, 0));
		}

		[Test]
		public void ApiAuthorization_Constructor_Null_AccessId_Throws_Exception()
		{
			Assert.Throws<ArgumentNullException>(() => new ApiAuthorization(null, "test", 0));
		}

		[Test]
		public void ApiAuthorization_Constructor_Null_SecretKey_Throws_exception()
		{
			Assert.Throws<ArgumentNullException>(() => new ApiAuthorization("test", null, 0));
		}

		[Test]
		public void ApiAuthorization_Valid_Constructor_Returns_Class()
		{
			var result = new ApiAuthorization("test", "test", 1);

			Assert.NotNull(result);
		}

		[Test]
		public void ApiAuthorization_AccessId_Property_Set()
		{
			var result = new ApiAuthorization("test", "test", 1);

			Assert.AreEqual("test", result.AccessId);
		}

		[Test]
		public void ApiAuthorization_SecretKey_Property_Set()
		{
			var result = new ApiAuthorization("test", "test", 1);

			Assert.AreEqual("test", result.SecretKey);
		}

		[Test]
		public void ApiAuthorization_ExpiresInterval_Property_Set()
		{
			var result = new ApiAuthorization("test", "test", 1);

			Assert.AreEqual(1, result.ExpiresInterval);
		}

		[Test]
		public void ApiAuthorization_GetAuthenticationString_Returns_String()
		{
			var apiAuthorization = new ApiAuthorization("test", "test", 1);

			var result = apiAuthorization.GetAuthenticationString();

			Assert.NotNull(result);
		}
	}
}
