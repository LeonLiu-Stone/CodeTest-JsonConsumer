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

		private List<PetInfo> _pets = new List<PetInfo>();

		public string Name { get; set; }

		public Gender Gender { get; set; } = Gender.UnKnow;

		public int Age { get; set; } = -1;

		public List<PetInfo> Pets { get => _pets == null ? new List<PetInfo>() : _pets; set => _pets = value; }
	}
}
