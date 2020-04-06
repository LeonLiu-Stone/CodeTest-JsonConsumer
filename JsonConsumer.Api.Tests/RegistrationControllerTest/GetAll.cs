using System;
using System.Net;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Xunit;

using JsonConsumer.Api.Controllers;
using JsonConsumer.Lib.Models;
using Moq;

namespace JsonConsumer.Api.Tests.RegistrationControllerTest {

	public class GetAll {

		[Fact]
		public async Task WhenJsonSourceIsValid_CanReturnAllRegistrations() {

			//Arrange
			var registrations = FakeModels.Registrations;
			var testViewData = FakeModels.CatsViewForRender;
			var renderingData = FakeModels.RenderingData;

			var stubILogger = StubHelper.StubILogger<RegistrationController>();
			var stubIFetchService = StubHelper.StubIFetchService;
			stubIFetchService.Setup(x => x.GetRegistrations())
				.Returns(Task.FromResult(registrations));
			var stubIVewingService = StubHelper.StubIVewingService;
			stubIVewingService.Setup(x => x.ViewRegistrations(It.IsAny<List<OwnerInfo>>(), ViewType.CatsUnderOnwersGender))
				.Returns(testViewData);
			var stubIRenderService = StubHelper.StubIRenderService;
			stubIRenderService.Setup(x => x.RenderRegistrations(It.IsAny<List<ResultFormat>>()))
				.Returns(renderingData);

			var testedService = new RegistrationController(stubILogger.Object,
				stubIFetchService.Object,
				stubIVewingService.Object,
				stubIRenderService.Object);

			//Act
			var result = await testedService.GetAll();
			var actual = result as ContentResult;

			//Assert
			Assert.Equal((int)HttpStatusCode.OK, actual.StatusCode);
		}

		[Fact]
		public async Task WhenJsonSourceIsNotValid_HTT500_CanReturnAnEmptyArray() {

			//Arrange
			var registrations = new List<OwnerInfo>();

			var stubILogger = StubHelper.StubILogger<RegistrationController>();
			var stubIFetchService = StubHelper.StubIFetchService;
			stubIFetchService.Setup(x => x.GetRegistrations())
				.Returns(Task.FromResult(registrations));
			var stubIRenderService = StubHelper.StubIRenderService;
			var stubIVewingService = StubHelper.StubIVewingService;

			var testedService = new RegistrationController(stubILogger.Object,
				stubIFetchService.Object,
				stubIVewingService.Object,
				stubIRenderService.Object);

			//Act
			var result = await testedService.GetAll();
			var actual = result as NoContentResult;

			//Assert
			Assert.Equal((int)HttpStatusCode.NoContent, actual.StatusCode);
		}
	}
}
