using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using ConsoleAppWheatherApi.Iterfaces;
using Newtonsoft.Json;

namespace ConsoleAppWheatherApi.WheatherApi
{
    public class WeatherApiOperations : IWeatherOperations
    {
        public async Task<WeatherReport> GetWeather(HttpClient client)
        {
            using (client)
            {
                var response = await client.GetAsync("");
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    var weather = await response.Content.ReadAsStringAsync();
                    var weatherReport = JsonParser(weather);
                    return weatherReport;
                }
                else
                {
                    throw new ArgumentException("response failed :("); //?
                }
            }
        }
        private static WeatherReport JsonParser(string weather)
        {
            var jobj = JObject.Parse(weather);
            var jToken = jobj.First;
            var weatherState = jToken.First["results"]["channel"]["item"]["condition"].ToString();
            var report = JsonConvert.DeserializeObject<WeatherReport>(weatherState);
            return report;
        }
    }
}
