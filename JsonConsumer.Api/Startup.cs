using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using JsonConsumer.Lib;
using JsonConsumer.Api.Middleware;
using JsonConsumer.Api.Services;

namespace JsonConsumer.Api {

	public class Startup {
		public Startup(IConfiguration configuration) {
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services) {
			services.AddControllers();
			SetDependencies(services, Configuration);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
			if (env.IsDevelopment()) {
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints => {
				endpoints.MapControllers();
			});

			app.ConfigureCustomMiddleware();
		}

		public void SetDependencies(IServiceCollection services, IConfiguration configuration) {
			services.Configure<JsonConsumerSettings>(configuration.GetSection("JsonConsumer"));
			services.AddSingleton<IExceptionFactory, ExceptionFactory>();
			services.AddSingleton<IRestApiService, RestApiService>();
			services.AddSingleton<IFetchService, FetchService>();
			services.AddSingleton<IRenderService, RenderService>();
			services.AddSingleton<IViewingService, CatsUnderOnwersGenderView>();
			services.AddSingleton<IViewingService, DogsUnderOnwersGenderView>();
			services.AddSingleton<IViewsService, ViewsService>();
		}
	}
}
