using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    class Program
    {
        static void Main(string[] args)
        {
             var client = new RestClient("http://ludoapp.azurewebsites.net/ludo");

           var request = new RestRequest("getallgames", Method.GET);
           IRestResponse response = client.Execute(request);
           var content = response.Content; // raw content as string
           Console.WriteLine(content);
                        Console.ReadKey();
        }
    }
}
