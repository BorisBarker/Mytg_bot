using Microsoft.Extensions.Configuration;
using System;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace Mytg_bot
{
    class InitBot
    {
        private static TelegramBotClient client;

        public static void Initialize()
        {
            client = new TelegramBotClient(Tokens.GetTelegramToken());
            client.StartReceiving();
            client.OnMessage += OnMessageHandlerAsync;

            Console.ReadLine();
            client.StopReceiving();
        }

        private static void OnMessageHandlerAsync(object sender, MessageEventArgs e)
        {
            var msg = e.Message;
            MsgHandler.HandlingAsync(client, msg);
        }
    }
}
