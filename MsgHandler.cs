using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;

namespace Mytg_bot
{
    class MsgHandler
    {
        public static string league = null;
        public static async void HandlingAsync(TelegramBotClient client, Telegram.Bot.Types.Message msg)
        {
            if (msg.Text != null)
            {
                string imgpath;
                string folderpath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\"));
                Console.WriteLine($"Yout text message: {msg.Text}");
                switch (msg.Text)
                {
                    case "/start":
                        await client.SendTextMessageAsync(msg.Chat.Id, "Choose league", replyMarkup: GetButtons_Leagues());
                        break;
                    case "🏴󠁧󠁢󠁥󠁮󠁧󠁿EPL":
                        imgpath = Path.Combine(folderpath, "league_pics\\barclays-logo.png");
                        PrintLogo(imgpath, client, msg);
                        league = msg.Text;
                        break;
                    case "🇪🇸LaLiga":
                        imgpath = Path.Combine(folderpath, "league_pics\\laliga_logo.png");
                        PrintLogo(imgpath, client, msg);
                        league = msg.Text;
                        break;
                    case "🇩🇪Bundesliga":
                        imgpath = Path.Combine(folderpath, "league_pics\\bundesliga_logo.png");
                        PrintLogo(imgpath, client, msg);
                        league = msg.Text;
                        break;
                    case "🇫🇷Ligue 1":
                        imgpath = Path.Combine(folderpath, "league_pics\\ligue1_logo.png");
                        PrintLogo(imgpath, client, msg);
                        league = msg.Text;
                        break;
                    case "🇮🇹Serie A":
                        imgpath = Path.Combine(folderpath, "league_pics\\serieA_logo.png");
                        PrintLogo(imgpath, client, msg);
                        league = msg.Text;
                        break;
                    case "🇷🇺RPL":
                        imgpath = Path.Combine(folderpath, "league_pics\\rfpl_logo.png");
                        PrintLogo(imgpath, client, msg);
                        league = msg.Text;
                        break;
                    case "🇳🇱Eredivisie":
                        imgpath = Path.Combine(folderpath, "league_pics\\eredivisie_logo.png");
                        PrintLogo(imgpath, client, msg);
                        league = msg.Text;
                        break;
                    case "🇵🇹Primeira Liga󠁧󠁢󠁥󠁮󠁧󠁿":
                        imgpath = Path.Combine(folderpath, "league_pics\\liga_portugal_logo.png");
                        PrintLogo(imgpath, client, msg);
                        league = msg.Text;
                        break;
                    case "Standings":
                        ParseApi.StandingsQuery(league);
                        break;
                    case "Upcoming matches󠁧󠁢󠁥󠁮󠁧󠁿":
                        ParseApi.UpcomingMatchesQuery(league);
                        break;
                    case "<< Back":
                        await client.SendTextMessageAsync(msg.Chat.Id, "Choose league", replyMarkup: GetButtons_Leagues());
                        break;
                    default:
                        await client.SendTextMessageAsync(chatId: msg.Chat.Id, "Use the buttons below 👇", replyMarkup: GetButtons_Leagues());
                        break;
                }
                Thread.Sleep(1000);
            }
        }

        static async void PrintLogo(string imgpath, TelegramBotClient client, Telegram.Bot.Types.Message msg)
        {
            using (var pic = File.OpenRead(imgpath))
            {
                await client.SendPhotoAsync(msg.Chat.Id, new Telegram.Bot.Types.InputFiles.InputOnlineFile(pic),
                    caption: $"You choose {msg.Text}!", replyMarkup: GetButtons_Statistics());
            }
        }

        private static IReplyMarkup GetButtons_Leagues()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton> { new KeyboardButton { Text = "🏴󠁧󠁢󠁥󠁮󠁧󠁿EPL" }, new KeyboardButton { Text = "🇪🇸LaLiga" },
                        new KeyboardButton { Text = "🇩🇪Bundesliga" }, new KeyboardButton { Text = "🇫🇷Ligue 1" } },
                    new List<KeyboardButton> { new KeyboardButton { Text = "🇮🇹Serie A" }, new KeyboardButton { Text = "🇷🇺RPL" },
                        new KeyboardButton { Text = "🇳🇱Eredivisie" }, new KeyboardButton { Text = "🇵🇹Primeira Liga󠁧󠁢󠁥󠁮󠁧󠁿" } }
                },
                ResizeKeyboard = true
            };
        }

        private static IReplyMarkup GetButtons_Statistics()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton> { new KeyboardButton { Text = "Standings" }, new KeyboardButton { Text = "Upcoming matches" } },
                    new List<KeyboardButton> { new KeyboardButton { Text = "<< Back" } },
                },
                ResizeKeyboard = true
            };
        }
    }
}
