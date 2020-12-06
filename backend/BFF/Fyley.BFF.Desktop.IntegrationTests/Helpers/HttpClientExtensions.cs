using System.Net.Http;
using System.Threading.Tasks;
using Fyley.Core.Asp.Models;
using Newtonsoft.Json;

namespace Fyley.BFF.Desktop.IntegrationTests.Helpers
{
    public static class HttpClientExtensions
    {
        public static Task<HttpResponseMessage> PostJsonAsync(this HttpClient httpClient, string url, object data)
        {
            return httpClient.PostAsync(url, new JsonContent(data));
        }

        public static async Task<ApiResponse<T>> ReadApiResponseOf<T>(this HttpResponseMessage response)
        {
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ApiResponse<T>>(json);
        }
    }
}