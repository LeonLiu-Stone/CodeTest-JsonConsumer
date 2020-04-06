using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

using JsonConsumer.Lib.Models;

namespace JsonConsumer.Api.Services {

	/// <summary>
	/// render registrations in expected format
	/// </summary>
	public interface IRenderService {
		List<string> RenderRegistrations(List<ResultFormat> results);
	}

	public class RenderService: IRenderService {

		private readonly ILogger _logger;

		public RenderService(ILogger<RenderService> logger) {
			_logger = logger;
		}

		public List<string> RenderRegistrations(List<ResultFormat> results) {
			throw new NotImplementedException();
		}
	}
}
