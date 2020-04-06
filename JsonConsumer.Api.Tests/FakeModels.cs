using System;
using System.Collections.Generic;

using JsonConsumer.Lib.Models;

namespace JsonConsumer.Api.Tests {

	public static class FakeModels {

		public static List<OwnerInfo> Registrations = new List<OwnerInfo> {
			new OwnerInfo("OwnerA", Gender.Male, 23, new List<PetInfo> {
					new PetInfo("CatA",PetType.Cat),
					new PetInfo("DogA", PetType.Dog)
				}),
			new OwnerInfo("OwnerB", Gender.Female, 65, new List<PetInfo> {
					new PetInfo("CatB",PetType.Cat),
					new PetInfo("CatC", PetType.Cat)
				}),
			new OwnerInfo("OwnerC", Gender.Female, 45, new List<PetInfo> {
					new PetInfo("DogB",PetType.Dog),
					new PetInfo("DogC", PetType.Dog)
				}),
			new OwnerInfo("OwnerD", Gender.Female, 36, new List<PetInfo>()),
			new OwnerInfo("OwnerE", Gender.Male, 55, new List<PetInfo> {
					new PetInfo("CatD",PetType.Cat),
					new PetInfo("FishA", PetType.Fish)
				})
		};

		public static List<ResultFormat> ViewDataForRender = new List<ResultFormat> {
			new ResultFormat("Male", new List<string>{ "PetA", "PetB", "PetC" }),
			new ResultFormat("Female", new List<string>{ "PetD", "PetE", "PetF" })
		};
	}
}
