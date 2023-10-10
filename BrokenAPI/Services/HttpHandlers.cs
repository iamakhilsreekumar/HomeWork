using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BrokenAPI.Services
{
    public class HttpHandlers
    {
        public readonly string ApiBaseUrl;
        public HttpHandlers(IConfiguration config)
        {
            ApiBaseUrl = config["startwarapiurl"];
        }

        public async Task<T> CallAPIAsync<T>()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new System.Uri(ApiBaseUrl);
            var result = await httpClient.GetAsync($"people");
            string resultString = await result.Content.ReadAsStringAsync();            
            return JsonConvert.DeserializeObject<T>(resultString);
        }
    }
}
