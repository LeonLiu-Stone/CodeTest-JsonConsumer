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

namespace JsonConsumer.Api.Tests.RenderServiceTest {

	public class RenderRegistrations {

		[Fact]
		public void WhenPrivateValidResults_CanRenderToExpectedFormat() {

			//Arrange
			var testViewData = FakeModels.CatsViewForRender;

			var stubILogger = StubHelper.StubILogger<RenderService>();

			var testedService = new RenderService(stubILogger.Object);

			//Act
			var actual = testedService.RenderRegistrations(testViewData);

			//Assert
			Assert.Contains("Female", actual);
		}
	}
}
