using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

using JsonConsumer.Lib.Models;

namespace JsonConsumer.Api.Services {

	/// <summary>
	/// support a expected view on registrations
	/// </summary>
	public interface IViewsService {
		List<ResultFormat> ViewRegistrations(List<OwnerInfo> registrations, ViewType viewType);
	}

	public class ViewsService : IViewsService {

		private readonly ILogger _logger;
		private IEnumerable<IViewingService> _viewingServices { get; set; }

		public ViewsService(ILogger<ViewsService> logger, IEnumerable<IViewingService> viewingServices) {
			_logger = logger;
			_viewingServices = viewingServices;
		}

		public List<ResultFormat> ViewRegistrations(List<OwnerInfo> registrations, ViewType viewType) {
			if (!(registrations?.Any() ?? false)) {
				return new List<ResultFormat>();
			}

			return _viewingServices.First(x => x.ViewSortType == viewType).SortRegistrations(registrations);
		}
	}
}
