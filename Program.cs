using System;
using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;

namespace Mytg_bot
{
    class Program
    {
        private static string token { get; set; } = "2075352178:AAG2mppW0psVNua9cX4DFhLPo6OQvnLeJnM";
        private static TelegramBotClient client;
        static void Main(string[] args)
        {
            client = new TelegramBotClient(token);
            client.StartReceiving();
            client.OnMessage += OnMessageHandlerAsync;

            Console.ReadLine();
            client.StopReceiving();
        }

        private static async void OnMessageHandlerAsync(object sender, MessageEventArgs e)
        {
            var msg = e.Message;
            if (msg.Text != null)
            {
                Console.WriteLine($"Yout text message: {msg.Text}");
                //await client.SendTextMessageAsync(msg.Chat.Id, msg.Text, replyToMessageId: msg.MessageId);
                //await client.SendTextMessageAsync(msg.Chat.Id, msg.Text, replyMarkup: GetButtons());
                switch (msg.Text)
                {
                    case "HOLA":
                        var stic = await client.SendStickerAsync(
                            chatId: msg.Chat.Id,
                            sticker: "https://cdn.tlgrm.app/stickers/dc7/a36/dc7a3659-1457-4506-9294-0d28f529bb0a/192/1.webp",
                            replyToMessageId: msg.MessageId);
                            break;
                    default:
                        await client.SendTextMessageAsync(msg.Chat.Id, msg.Text, replyToMessageId: msg.MessageId);
                        break;
                }
            }
        }

        private static IReplyMarkup GetButtons()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton>{ new KeyboardButton { Text = "Hello" }, new KeyboardButton { Text = "GoodBye!" } },
                    new List<KeyboardButton>{ new KeyboardButton { Text = "HOLA" }, new KeyboardButton { Text = "ADIOS!" } }
                }
            };
        }
    }
}
