using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using ConsoleAppWheatherApi.Iterfaces;

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
                    return new WeatherReport(); //?
                }
            }
        }
        private static WeatherReport JsonParser(string weather)
        {
            JObject jobj = JObject.Parse(weather);
            JToken jToken = jobj.First;
            string weatherState = jToken.First["results"]["channel"]["item"]["condition"].ToString();
            WeatherReport report = Newtonsoft.Json.JsonConvert.DeserializeObject<WeatherReport>(weatherState);
            return report;
        }
    }
}
