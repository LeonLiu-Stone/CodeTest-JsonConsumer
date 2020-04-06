using System;

namespace JsonConsumer.Lib.Models {

	public class PetInfo {

		public PetInfo() { }

		public PetInfo(string name, PetType type) {
			Name = name;
			Type = type;
		}

		public string Name { get; set; }

		public PetType Type { get; set; } = PetType.UnKnow;
	}
}
