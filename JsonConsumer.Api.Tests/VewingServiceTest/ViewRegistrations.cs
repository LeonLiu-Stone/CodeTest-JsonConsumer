using System.Linq;

using Xunit;

using JsonConsumer.Api.Services;
using JsonConsumer.Lib.Models;

namespace JsonConsumer.Api.Tests.VewingServiceTest {

	public class ViewRegistrations {

		[Fact]
		public void WhenPrivateValidRegistrations_CanReturnExceptedView() {

			//Arrange
			var registrations = FakeModels.Registrations;
			var viewType = ViewType.CatsUnderOnwersGender;

			var stubILogger = StubHelper.StubILogger<VewingService>();

			var testedService = new VewingService(stubILogger.Object);

			//Act
			var actual = testedService.ViewRegistrations(registrations, viewType);

			//Assert
			//the total items of actaul should be equal to the number of cats in the registration
			Assert.Equal(registrations.SelectMany(x => x.Pets).ToList().Count(x => x.Type == PetType.Cat),
				actual.SelectMany(x => x.Items).ToList().Count);
		}
	}
}
