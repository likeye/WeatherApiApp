using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using ConsoleAppWheatherApi.Interfaces;

namespace ConsoleAppWheatherApi.Services
{
    public class HttpService : IHttp
    {
        public HttpClient Connect(string woeid)
        {
            var client = new HttpClient()
            {
                BaseAddress =
                    new Uri(
                        $"https://query.yahooapis.com/v1/public/yql?q=select%20item%20from%20weather.forecast%20where%20woeid%20in%20({woeid}%20)&format=json"),
                DefaultRequestHeaders =
                {
                    Accept = {new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")}
                }
            };
            return client;
        }
    }
}
