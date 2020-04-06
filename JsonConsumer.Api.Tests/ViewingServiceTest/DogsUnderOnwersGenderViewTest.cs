using System.Linq;
using Xunit;

using JsonConsumer.Api.Services;
using JsonConsumer.Lib.Models;

namespace JsonConsumer.Api.Tests.ViewingServiceTest {

	public class DogsUnderOnwersGenderViewTest {

		[Fact]
		public void WhenPrivateValidRegistrations_CanReturnExceptedDogsView() {

			//Arrange
			var registrations = FakeModels.Registrations;

			var stubILogger = StubHelper.StubILogger<DogsUnderOnwersGenderView>();

			var testedService = new DogsUnderOnwersGenderView(stubILogger.Object);

			//Act
			var actual = testedService.SortRegistrations(registrations);

			//Assert
			//the total items of actaul should be equal to the number of cats in the registration
			Assert.Equal(registrations.SelectMany(x => x.Pets).ToList().Count(x => x.Type == PetType.Dog),
				actual.SelectMany(x => x.Items).ToList().Count);
		}
	}
}
