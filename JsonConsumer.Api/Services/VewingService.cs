using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

using JsonConsumer.Lib.Models;

namespace JsonConsumer.Api.Services {

	/// <summary>
	/// support a expected view on registrations
	/// </summary>
	public interface IVewingService {
		List<ResultFormat> ViewRegistrations(List<OwnerInfo> registrations, ViewType viewType);
	}

	public class VewingService : IVewingService {

		private readonly ILogger _logger;

		public VewingService(ILogger<VewingService> logger) {
			_logger = logger;
		}

		public List<ResultFormat> ViewRegistrations(List<OwnerInfo> registrations, ViewType viewType) {
			throw new NotImplementedException();
		}
	}
}
