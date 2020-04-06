using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

using JsonConsumer.Lib.Models;

namespace JsonConsumer.Api.Services {

	public interface IViewingService {
		ViewType ViewSortType { get; }
		List<ResultFormat> SortRegistrations(List<OwnerInfo> registrations);
	}

	public class CatsUnderOnwersGenderView : IViewingService {
		private readonly ILogger _logger;

		public CatsUnderOnwersGenderView(ILogger<CatsUnderOnwersGenderView> logger) {
			_logger = logger;
		}

		ViewType IViewingService.ViewSortType => ViewType.CatsUnderOnwersGender;

		public List<ResultFormat> SortRegistrations(List<OwnerInfo> registrations) {
			if (!(registrations?.Any() ?? false)) {
				return new List<ResultFormat>();
			}

			return registrations
				.SelectMany(petOwner => petOwner.Pets, (petOwner, pet) => new { petOwner, pet })
				.Where(ownerAndPet => ownerAndPet.pet.Type == PetType.Cat)
				.GroupBy(g => g.petOwner.Gender, g => g.pet.Name)
				.Select(x => new ResultFormat(x.Key.ToString(), x.ToList()))
				.ToList();
		}
	}

	public class DogsUnderOnwersGenderView : IViewingService {
		private readonly ILogger _logger;

		public DogsUnderOnwersGenderView(ILogger<DogsUnderOnwersGenderView> logger) {
			_logger = logger;
		}

		ViewType IViewingService.ViewSortType => ViewType.DogsUnderOnwersGender;

		public List<ResultFormat> SortRegistrations(List<OwnerInfo> registrations) {
			if (!(registrations?.Any() ?? false)) {
				return new List<ResultFormat>();
			}

			return registrations
				.SelectMany(petOwner => petOwner.Pets, (petOwner, pet) => new { petOwner, pet })
				.Where(ownerAndPet => ownerAndPet.pet.Type == PetType.Dog)
				.GroupBy(g => g.petOwner.Gender, g => g.pet.Name)
				.Select(x => new ResultFormat(x.Key.ToString(), x.ToList()))
				.ToList();
		}
	}
}
