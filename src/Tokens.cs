using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mytg_bot
{
    class Tokens
    {
        public static string GetTelegramToken()
        {
            var config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .AddUserSecrets<Tokens>()
            .Build();

            return config.GetConnectionString("TokenTG");
        }

        public static string GetRapidAPIToken()
        {
            var config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .AddUserSecrets<Tokens>()
            .Build();

            return config.GetConnectionString("TokenRapid");
        }
    }
}
