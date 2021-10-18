using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mytg_bot
{
    class ParseApi
    {
        static async void GetInfo()
        {
            var client = new RestClient("https://api-football-v1.p.rapidapi.com/v3/standings?season=2021&league=39");
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", "api-football-v1.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", "2472836ce0mshcb688e7d49b9ecap14af26jsnc3012beab4a4");
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
        }
    }
}
