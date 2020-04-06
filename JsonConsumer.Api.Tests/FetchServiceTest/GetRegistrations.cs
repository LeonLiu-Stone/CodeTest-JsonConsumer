using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using Xunit;
using Moq;

using JsonConsumer.Api.Services;
using JsonConsumer.Lib.Models;

namespace JsonConsumer.Api.Tests.FetchServiceTest {

	public class GetRegistrations {

		[Fact]
		public async Task WhenJsonSourceIsValid_CanReturnRegistrations() {

			//Arrange
			var registrations = FakeModels.Registrations;
			var settings = new JsonConsumerSettings();

			var stubILogger = StubHelper.StubILogger<FetchService>();
			var stubIExceptionFactory = StubHelper.StubIExceptionFactory;
			var stubIRestApiService = StubHelper.StubIRestApiService;
			stubIRestApiService.Setup(x => x.GetRequestAsync<List<OwnerInfo>>(It.IsAny<string>()))
				.Returns(Task.FromResult(registrations));

			var testedService = new FetchService(stubILogger.Object,
				stubIExceptionFactory.Object,
				stubIRestApiService.Object,
				Options.Create(settings));

			//Act
			var actual = await testedService.GetRegistrations();

			//Assert
			Assert.Equal(registrations.Count, actual.Count);
		}

		[Fact]
		public async Task WhenJsonSourceIsNotValid_CanReturnAnEmptyList() {

			//Arrange
			List<OwnerInfo> registrations = null;
			var settings = new JsonConsumerSettings();

			var stubILogger = StubHelper.StubILogger<FetchService>();
			var stubIExceptionFactory = StubHelper.StubIExceptionFactory;
			var stubIRestApiService = StubHelper.StubIRestApiService;
			stubIRestApiService.Setup(x => x.GetRequestAsync<List<OwnerInfo>>(It.IsAny<string>()))
				.Returns(Task.FromResult(registrations));

			var testedService = new FetchService(stubILogger.Object,
				stubIExceptionFactory.Object,
				stubIRestApiService.Object,
				Options.Create(settings));

			//Act
			var actual = await testedService.GetRegistrations();

			//Assert
			Assert.False(actual.Any());
		}
	}
}
