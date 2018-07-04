using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppWheatherApi.Iterfaces
{
    public interface IWeatherOperations
    {
        Task<WeatherReport> GetWeather(HttpClient client);
    }
}
