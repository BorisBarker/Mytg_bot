using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.UserSecrets;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace Mytg_bot
{
    class Program
    {
        static void Main()
        {
            InitBot.Initialize();
        }
    }
}