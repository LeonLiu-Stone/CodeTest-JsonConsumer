using System;
using Microsoft.AspNetCore.Builder;

namespace JsonConsumer.Api.Middleware {

	public static class MiddlewareExtensions {

		public static void ConfigureCustomMiddleware(this IApplicationBuilder app) {
			app.UseMiddleware<ExceptionMiddleware>();
			//app.UseMiddleware<RequestResponseMiddleware>();
		}
	}
}
