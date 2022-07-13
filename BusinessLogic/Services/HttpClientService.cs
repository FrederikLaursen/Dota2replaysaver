using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class HttpClientService : IHttpClientService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public HttpClientService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<string> Get(string url)
        {
            var httpRequestMessage = new HttpRequestMessage(
           HttpMethod.Get, url);


            var httpClient = _httpClientFactory.CreateClient();
           // var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                // using var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();
                string apiResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                return apiResponse;
            } else
            {
                return "";
            }
        }
    }
}