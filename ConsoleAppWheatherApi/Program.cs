using System;
using System.Threading.Tasks;
using ConsoleAppWheatherApi.Services;
using ConsoleAppWheatherApi.WheatherApi;

namespace ConsoleAppWheatherApi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World! \n");

            HttpService httpService = new HttpService();
            WeatherApiOperations weatherApi = new WeatherApiOperations();

            var client1 = httpService.Connect("44418"); //Londyn
            var client2 = httpService.Connect("523920"); // Warszawa
            var client3 = httpService.Connect("615702"); // Paryż
            var client4 = httpService.Connect("796597"); // Praga
            var report1 = weatherApi.GetWeather(client1);
            var report2 = weatherApi.GetWeather(client2);
            var report3 = weatherApi.GetWeather(client3);
            var report4 = weatherApi.GetWeather(client4);
            
            Console.WriteLine("\n");
            Console.WriteLine("City: London");
            TempDetails(report1);
            Console.WriteLine("\n");
            Console.WriteLine("City: Warsaw");
            TempDetails(report2);
            Console.WriteLine("\n");
            Console.WriteLine("City: Paris");
            TempDetails(report3);
            Console.WriteLine("\n");
            Console.WriteLine("City: Prague");
            TempDetails(report4);
            Console.ReadKey();
        }

        private static void TempDetails(Task<WeatherReport> report)
        {
            Console.WriteLine("Temperature Details");
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("Temperature: " + (report.Result.temp - 32) * 0.5);// na celcjusze 
            Console.WriteLine("Weather State: " + report.Result.text);
            Console.WriteLine("Time: " + report.Result.date);
        }
    }
}
