using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace JsonConsumer.Api.Controllers {

	/// <summary>
	/// Haven't set Healthy-Check, ApiVersioning and Swagger yet,
	/// but will show it during the interview 
	/// </summary>
	[ApiController]
	[Produces("application/json")]
	[ApiVersion("1.0")]
	[Route("api/v{version:apiVersion}/[controller]")]
	public class RegistrationController : BaseController {

		private readonly ILogger<RegistrationController> _logger;

		public RegistrationController(ILogger<RegistrationController> logger) {
			_logger = logger;
		}

		/// <summary>
		/// Get a full list of registration
		/// </summary>
		/// <returns>a list of registration</returns>
		/// <response code="200">returns registrations</response>
		/// <response code="204">no registration be found</response>
		[HttpGet]
		public async Task<IActionResult> GetAll() {

			//TODO: actual business logical
			return OkResponse();
		}

		/// <summary>
		/// Get a registration info by a given owner name
		/// </summary>
		/// <returns>a registration info</returns>
		/// <response code="200">returns a registration info</response>
		/// <response code="204">no registration be found</response>
		[HttpGet("Owner")]
		public async Task<IActionResult> GetByOwner(string ownerName) {

			//TODO: actual business logical
			return OkResponse();
		}
	}
}
