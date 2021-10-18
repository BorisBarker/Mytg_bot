using System;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace Mytg_bot
{
    class InitBot
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
