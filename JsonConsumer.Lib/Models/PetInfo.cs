using System;

namespace JsonConsumer.Lib.Models {

	public class PetInfo {

		public string Name { get; set; }

		public PetType Type { get; set; } = PetType.UnKnow;
	}
}
