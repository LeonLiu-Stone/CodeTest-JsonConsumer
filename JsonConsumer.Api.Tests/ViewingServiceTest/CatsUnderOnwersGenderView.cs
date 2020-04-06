using System.Linq;
using Xunit;

using JsonConsumer.Api.Services;
using JsonConsumer.Lib.Models;

namespace JsonConsumer.Api.Tests.ViewingServiceTest {

	public class CatsUnderOnwersGenderViewTest {

		[Fact]
		public void WhenPrivateValidRegistrations_CanReturnExceptedCatsView() {

			//Arrange
			var registrations = FakeModels.Registrations;

			var stubILogger = StubHelper.StubILogger<CatsUnderOnwersGenderView>();

			var testedService = new CatsUnderOnwersGenderView(stubILogger.Object);

			//Act
			var actual = testedService.SortRegistrations(registrations);

			//Assert
			//the total items of actaul should be equal to the number of cats in the registration
			Assert.Equal(registrations.SelectMany(x => x.Pets).ToList().Count(x => x.Type == PetType.Cat),
				actual.SelectMany(x => x.Items).ToList().Count);
		}
	}
}
