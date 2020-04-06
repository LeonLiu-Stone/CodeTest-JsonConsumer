using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace JsonConsumer.Lib {

	public interface IRestApiService {
		Task<T> GetRequestAsync<T>(string url);
	}

	public class RestApiService: IRestApiService {

		public async Task<T> GetRequestAsync<T>(string url) {

			using var client = new HttpClient();
			//Setting up the response...        
			using var res = await client.GetAsync(url);
			if ((int)res.StatusCode >= 400)
				throw new ErrorException($"Http GET request exception: {res.StatusCode}: {res.Content}");
			using var content = res.Content;
			var jsonResponse = await content.ReadAsStringAsync();
			return JsonHelper.DeserializeObject<T>(jsonResponse);
		}
	}
}
