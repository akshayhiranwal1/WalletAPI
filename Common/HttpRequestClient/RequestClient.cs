using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WalletAPI.Common.HttpRequestClient
{
    public class RequestClient : IRequestClient
    {
        private HttpClient AddAuthHeaderToHttpClient(HttpClient httpClient)
        {
            if (httpClient is null || httpClient.DefaultRequestHeaders is null || httpClient.DefaultRequestHeaders.Authorization is null)
            {
                httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token.BearerToken);
            }
            return httpClient;
        }

        public async Task<string> GetAsync(string url)
        {
            using (var httpClient = AddAuthHeaderToHttpClient(new HttpClient()))
            {
                using (var response = await httpClient.GetAsync(url))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    return apiResponse;
                }
            }
        }

        public async Task<string> PatchAsync(string url, dynamic model)
        {
            using (var httpClient = AddAuthHeaderToHttpClient(new HttpClient()))
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PatchAsync(url, content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    return apiResponse;
                }
            }
        }

        public async Task<string> PostAsync(string url, dynamic model)
        {
            using (var httpClient = AddAuthHeaderToHttpClient(new HttpClient()))
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync(url, content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    return apiResponse;
                }
            }
        }
        public async Task<string> PutAsync(string url, dynamic model)
        {
            using (var httpClient = AddAuthHeaderToHttpClient(new HttpClient()))
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PutAsync(url, content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    return apiResponse;
                }
            }
        }
    }
}
