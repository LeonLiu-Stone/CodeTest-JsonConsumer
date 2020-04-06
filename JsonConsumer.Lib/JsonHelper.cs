using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace JsonConsumer.Lib {

	/// <summary>
	/// a custom resolver to convert the property name to camel case
	/// </summary>
	public class CamelCaseExceptDictionaryKeysResolver : CamelCasePropertyNamesContractResolver {
		protected override JsonDictionaryContract CreateDictionaryContract(Type objectType) {
			JsonDictionaryContract contract = base.CreateDictionaryContract(objectType);
			contract.DictionaryKeyResolver = propertyName => propertyName;
			return contract;
		}
	}

	public static class JsonHelper {

		public static readonly string JSON_DATE_FORMAT = "yyyy-MM-ddTHH:mm:ssZ";

		public static JsonSerializerSettings conversionSettings = new JsonSerializerSettings {
			DateFormatString = JSON_DATE_FORMAT,
			ContractResolver = new CamelCaseExceptDictionaryKeysResolver()
		};

		/// <summary>
		/// Deserializes the object.
		/// </summary>
		/// <returns>The object.</returns>
		/// <param name="json">Json.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public static T DeserializeObject<T>(string json) {
			return JsonConvert.DeserializeObject<T>(json);
		}

		/// <summary>
		/// Serializes the object.
		/// </summary>
		/// <returns>The object.</returns>
		/// <param name="model">Model.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public static string SerializeObject<T>(T model) {
			return JsonConvert.SerializeObject(model, conversionSettings);
		}

		/// <summary>
		/// Serializes the object.
		/// </summary>
		/// <returns>The object.</returns>
		/// <param name="model">Model.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public static string SerializeObjectWithLowercase<T>(T model) {
			return JsonConvert.SerializeObject(model, conversionSettings);
		}
	}
}
