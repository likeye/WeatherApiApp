using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ConsoleAppWheatherApi.Interfaces
{
    public interface IHttp
    {
        HttpClient Connect(string woeid);
    }
}
