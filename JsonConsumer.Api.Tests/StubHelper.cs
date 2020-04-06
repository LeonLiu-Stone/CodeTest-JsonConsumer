using System;
using JsonConsumer.Api.Services;
using JsonConsumer.Lib;
using Microsoft.Extensions.Logging;

using Moq;

namespace JsonConsumer.Api.Tests {

	public class StubHelper {

		public static Mock<ILogger<T>> StubILogger<T>() where T : class => new Mock<ILogger<T>>();

		public static Mock<IExceptionFactory> StubIExceptionFactory => new Mock<IExceptionFactory>();

		public static Mock<IFetchService> StubIFetchService => new Mock<IFetchService>();

		public static Mock<IRenderService> StubIRenderService => new Mock<IRenderService>();

		public static Mock<IVewingService> StubIVewingService => new Mock<IVewingService>();

		public static Mock<IRestApiService> StubIRestApiService => new Mock<IRestApiService>();

		public static void VerifyLog<T>(Mock<ILogger<T>> logger, LogLevel level, string message) {
			logger.Verify(x => x.Log(level, It.IsAny<EventId>(), It.Is<object>(o => o.ToString().Contains(message)), It.IsAny<Exception>(), It.IsAny<Func<object, Exception, string>>()), Times.Once);
		}
	}
}
