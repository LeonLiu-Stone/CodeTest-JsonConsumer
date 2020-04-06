using System;
using System.Collections.Generic;

namespace JsonConsumer.Lib.Models {

	public class ResultFormat {

		public ResultFormat() { }

		public ResultFormat(string heading, List<string> items) {
			Heading = heading;
			Items = items;
		}

		public string Heading { get; set; }

		public List<string> Items { get; set; }
	}
}
