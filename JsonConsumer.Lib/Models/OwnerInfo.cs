using System;
using System.Collections.Generic;

namespace JsonConsumer.Lib.Models {

	public class OwnerInfo {

		public OwnerInfo() { }

		public OwnerInfo(string name, Gender gender, int age, List<PetInfo> pets) {
			Name = name;
			Gender = gender;
			Age = age;
			Pets = pets;
		}

		public string Name { get; set; }

		public Gender Gender { get; set; } = Gender.UnKnow;

		public int Age { get; set; } = -1;

		public List<PetInfo> Pets { get; set; } = new List<PetInfo>();
	}
}
