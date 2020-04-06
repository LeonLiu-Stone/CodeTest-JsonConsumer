using System;
using System.Net;
using System.Threading.Tasks;
using JsonConsumer.Lib;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace JsonConsumer.Api.Middleware {

	public class ExceptionMiddleware {

		private readonly ILogger _logger;
		private readonly RequestDelegate _next;

		public ExceptionMiddleware(
			RequestDelegate next
			, ILogger<ExceptionMiddleware> logger) {
			_logger = logger;
			_next = next;
		}

		public async Task Invoke(HttpContext httpContext) {
			try {
				await _next(httpContext);
			}
			catch (CustomException ex) {
				await HandleExceptionAsync(httpContext, ex);
			}
			catch (Exception ex) {
				_logger.LogError(ex, $"Unknown exception: {ex.Message}:{ex.StackTrace}");
				await HandleExceptionAsync(httpContext, ex);
			}
		}

		private static Task HandleExceptionAsync(HttpContext context, Exception exception) {
			context.Response.ContentType = "application/json";
			context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

			return context.Response.WriteAsync($"Internal Server Error({context.Response.StatusCode}): {exception.Message}");
		}
	}
}