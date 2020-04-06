using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using JsonConsumer.Api.Services;
using JsonConsumer.Lib.Models;

namespace JsonConsumer.Api.Controllers {

	/// <summary>
	/// Haven't set Healthy-Check, ApiVersioning and Swagger yet,
	/// but will show it during the interview 
	/// </summary>
	[ApiController]
	[Route("api/[controller]")]
	public class RegistrationController : BaseController {

		private readonly ILogger<RegistrationController> _logger;
		private readonly IFetchService _fetchService;
		private readonly IViewsService _vewingService;
		private readonly IRenderService _renderService;

		public RegistrationController(ILogger<RegistrationController> logger,
			IFetchService fetchService,
			IViewsService vewingService,
			IRenderService renderService) {
			_logger = logger;
			_fetchService = fetchService;
			_vewingService = vewingService;
			_renderService = renderService;
		}

		/// <summary>
		/// Get a full list of registration
		/// </summary>
		/// <returns>a list of registration</returns>
		/// <response code="200">returns registrations</response>
		/// <response code="204">no registration be found</response>
		[HttpGet]
		public async Task<IActionResult> GetAll() {

			var registrations = await _fetchService.GetRegistrations();
			if (!(registrations?.Any() ?? false)) {
				return NoContent();
			}

			var view = _vewingService.ViewRegistrations(registrations, ViewType.CatsUnderOnwersGender);
			var returnData = _renderService.RenderRegistrations(view);

			return OkResponse(returnData);
		}
	}
}
