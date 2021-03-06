﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using JsonConsumer.Lib;
using JsonConsumer.Lib.Models;
using System.Linq;

namespace JsonConsumer.Api.Services {

	/// <summary>
	/// fetch registration from data source
	/// </summary>
	public interface IFetchService {
		Task<List<OwnerInfo>> GetRegistrations();
	}

	public class FetchService: IFetchService {

		private readonly ILogger _logger;
		private readonly IExceptionFactory _exceptionFactory;
		private readonly IRestApiService _restApiService;
		private readonly JsonConsumerSettings _settings;

		public FetchService(
			ILogger<FetchService> logger,
			IExceptionFactory exceptionFactory,
			IRestApiService restApiService,
			IOptions<JsonConsumerSettings> settings) {
			_logger = logger;
			_exceptionFactory = exceptionFactory;
			_restApiService = restApiService;
			_settings = settings.Value;
		}

		public async Task<List<OwnerInfo>> GetRegistrations() {
			try {
				var registrations = await _restApiService.GetRequestAsync<List<OwnerInfo>>(_settings.JsonSourceUrl);
				return registrations?.Any() ?? false ? registrations : new List<OwnerInfo>();
			}
			catch (Exception ex) {
				_logger.LogError("Failed to get registrations from data source", ex);
				return new List<OwnerInfo>();
			}
		}
	}
}
