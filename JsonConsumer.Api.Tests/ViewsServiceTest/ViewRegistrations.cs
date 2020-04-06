using System.Linq;
using System.Collections.Generic;

using Moq;
using Xunit;

using JsonConsumer.Api.Services;
using JsonConsumer.Lib.Models;

namespace JsonConsumer.Api.Tests.VewingServiceTest {

	public class ViewRegistrations {

		[Fact]
		public void WhenPrivateValidRegistrations_CanReturnExceptedView() {

			//Arrange
			var registrations = FakeModels.Registrations;
			var testViewType = ViewType.CatsUnderOnwersGender;

			var stubILogger = StubHelper.StubILogger<ViewsService>();
			var stubViewingServiceA = StubHelper.StubIViewingService;
			stubViewingServiceA.Setup(x => x.ViewSortType)
				.Returns(testViewType);
			stubViewingServiceA.Setup(x => x.SortRegistrations(It.IsAny<List<OwnerInfo>>()))
				.Returns(FakeModels.CatsViewForRender);
			var stubViewingServiceB = StubHelper.StubIViewingService;
			stubViewingServiceB.Setup(x => x.ViewSortType)
				.Returns(ViewType.DogsUnderOnwersGender);
			stubViewingServiceB.Setup(x => x.SortRegistrations(It.IsAny<List<OwnerInfo>>()))
				.Returns(FakeModels.DogsViewForRender);

			var _viewingServices = new List<IViewingService> { stubViewingServiceA.Object, stubViewingServiceB.Object };

			var testedService = new ViewsService(stubILogger.Object, _viewingServices);

			//Act
			var actual = testedService.ViewRegistrations(registrations, testViewType);

			//Assert
			//the total items of actaul should be equal to the number of cats in the registration
			Assert.Equal(FakeModels.CatsViewForRender.SelectMany(x => x.Items).ToList().Count,
				actual.SelectMany(x => x.Items).ToList().Count);
		}
	}
}
