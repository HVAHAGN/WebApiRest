using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
namespace WeatherApiApp
{
    class Program
    {
        static void Main(string[] args)
        {

            string url = "http://api.openweathermap.org/data/2.5/weather?q=Yerevan&units=metric&appid=8b251d80390bc26ca5293024d0fbacbe";
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            string response;
            using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                response = streamReader.ReadToEnd();
            }


            WeatherResponse weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(response);
            Console.WriteLine("Temperature in {0} : {1} C°", weatherResponse.Name, weatherResponse.Main.Temp);

            Console.ReadLine();


        }
    }

}