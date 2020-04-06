using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

using JsonConsumer.Lib.Models;
using System.Linq;
using System.Text;

namespace JsonConsumer.Api.Services {

	/// <summary>
	/// render registrations in expected format
	/// </summary>
	public interface IRenderService {
		string RenderRegistrations(List<ResultFormat> results);
	}

	public class RenderService: IRenderService {

		private readonly ILogger _logger;

		public RenderService(ILogger<RenderService> logger) {
			_logger = logger;
		}

		public string RenderRegistrations(List<ResultFormat> results) {
			var renderResponse = new StringBuilder();
			results.ForEach(x => {
				renderResponse.AppendLine(x.Heading);
				x.Items.ForEach(item => renderResponse.AppendLine($"  • {item}"));
			});
			return renderResponse.ToString();
		}
	}
}
