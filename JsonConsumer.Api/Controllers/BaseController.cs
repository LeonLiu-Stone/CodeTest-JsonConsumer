using Microsoft.AspNetCore.Mvc;

namespace JsonConsumer.Api.Controllers {

	public class BaseController : ControllerBase {

		protected IActionResult OkResponse() {
			return Ok();
		}

		protected IActionResult OkResponse<T>(T response) {
			return Ok(response);
		}

		protected IActionResult BadResponse<T>(T response) {
			return BadRequest(response);
		}

		protected IActionResult NoContentResponse() {
			return NoContent();
		}
	}
}
