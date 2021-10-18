using System;
using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;

namespace Mytg_bot
{
    class Init_bot
    {
        private static string token { get; set; } = "2075352178:AAG2mppW0psVNua9cX4DFhLPo6OQvnLeJnM";
        private static TelegramBotClient client;

        public static void Initialize()
        {
            client = new TelegramBotClient(token);
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
