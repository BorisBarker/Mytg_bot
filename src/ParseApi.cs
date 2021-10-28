using Newtonsoft.Json;
using RestSharp;
using System;
using System.IO;
using System.Xml.Linq;

namespace Mytg_bot
{
    class ParseApi
    {
        public static async void StandingsQuery(string country)
        {
            var client = new RestClient("https://api-football-v1.p.rapidapi.com/v3/standings?season=2021&league=" + CountryToIndex(country));
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", "api-football-v1.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", Tokens.GetRapidAPIToken());
            IRestResponse response = await client.ExecuteAsync(request);
            ChooseLeagueToWrite(country, response);
        }

        public static async void UpcomingMatchesQuery(string country)
        {
            CountryToIndex(country);
            var client = new RestClient("https://api-football-v1.p.rapidapi.com/v3/standings?season=2021&league=" + "");
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", "api-football-v1.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", Tokens.GetRapidAPIToken());
            //IRestResponse response = await client.ExecuteAsync(request);
            //Console.WriteLine(response.Content);
        }

        private static string CountryToIndex(string index)
        {
            switch (index)
            {
                case LeagueName.Eng:
                    return "39";
                case LeagueName.Spa:
                    return "140";
                case LeagueName.Ger:
                    return "78";
                case LeagueName.Fra:
                    return "61";
                case LeagueName.Ita:
                    return "135";
                case LeagueName.Rus:
                    return "235";
                case LeagueName.Net:
                    return "88";
                case LeagueName.Por:
                    return "94";
            }
            Console.WriteLine("ERROR!");
            return null;
        }

        private static void ChooseLeagueToWrite(string country, IRestResponse response)
        {
            string jsonpath;
            string folderpath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\"));
            switch (country)
            {
                case LeagueName.Eng:
                    jsonpath = Path.Combine(folderpath, "league_json\\Eng_league.json");
                    WriteJsonToFile(response, jsonpath);
                    break;
                case LeagueName.Spa:
                    jsonpath = Path.Combine(folderpath, "league_json\\Spa_league.json");
                    WriteJsonToFile(response, jsonpath);
                    break;
                case LeagueName.Ger:
                    jsonpath = Path.Combine(folderpath, "league_json\\Ger_league.json");
                    WriteJsonToFile(response, jsonpath);
                    break;
                case LeagueName.Fra:
                    jsonpath = Path.Combine(folderpath, "league_json\\Fra_league.json");
                    WriteJsonToFile(response, jsonpath);
                    break;
                case LeagueName.Ita:
                    jsonpath = Path.Combine(folderpath, "league_json\\Ita_league.json");
                    WriteJsonToFile(response, jsonpath);
                    break;
                case LeagueName.Rus:
                    jsonpath = Path.Combine(folderpath, "league_json\\Rus_league.json");
                    WriteJsonToFile(response, jsonpath);
                    break;
                case LeagueName.Net:
                    jsonpath = Path.Combine(folderpath, "league_json\\Net_league.json");
                    WriteJsonToFile(response, jsonpath);
                    break;
                case LeagueName.Por:
                    jsonpath = Path.Combine(folderpath, "league_json\\Por_league.json");
                    WriteJsonToFile(response, jsonpath);
                    break;
            }
        }

        private static async void WriteJsonToFile(IRestResponse response, string path)
        {
            try
            {
                //open file stream
                await using (StreamWriter file = File.CreateText(@path))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    //serialize object directly into file stream
                    serializer.Serialize(file, response.Content);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
