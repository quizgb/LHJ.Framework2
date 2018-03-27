using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Discord;
using Discord.Commands;
using Discord.Net.Providers.WS4Net;
using Discord.WebSocket;

namespace LHJ.DiscordBot
{
    public class Program
    {
        private readonly DiscordSocketClient _client;

        // Program entry point
        static void Main(string[] args)
        {
            // Call the Program constructor, followed by the 
            // MainAsync method and wait until it finishes (which should be never).
            new Program().MainAsync().GetAwaiter().GetResult();
        }

        private Program()
        {
            this._client = new DiscordSocketClient(new DiscordSocketConfig
            {
                // How much logging do you want to see?
                LogLevel = LogSeverity.Info,

                // If you or another service needs to do anything with messages
                // (eg. checking Reactions, checking the content of edited/deleted messages),
                // you must set the MessageCacheSize. You may adjust the number as needed.
                //MessageCacheSize = 50,

                // If your platform doesn't have native websockets,
                // add Discord.Net.Providers.WS4Net from NuGet,
                // add the `using` at the top, and uncomment this line:
                WebSocketProvider = WS4NetProvider.Instance
            });
        }

        public async Task MainAsync()
        {
            string token = "NDI4MDIzNTg3NzE1NDE2MDg0.DZuRkQ.pmhaNOIDJ1-1mg6wgUARLNHfFkk";

            this._client.Log += Logger;

            await this._client.LoginAsync(TokenType.Bot, token);
            await this._client.StartAsync();

            this._client.MessageReceived += MessageReceived;
            this._client.Ready += Client_Ready;
            this._client.GuildAvailable += Client_GuildAvailable;

            await Task.Delay(-1); // 프로그램 종료시까지 태스크 유지  
        }

        private Task Client_GuildAvailable(SocketGuild arg)
        {
            //arg.Channels[0].SendMessageAsync("테스트 봇 시작!");
            return Task.CompletedTask;
        }

        private Task Client_Ready()
        {
            //arg.Channels[0].SendMessageAsync("테스트 봇 시작!");
            return Task.CompletedTask;
        }

        private async Task MessageReceived(SocketMessage message)
        {
            SocketUser user = message.Author;

            if (user.IsBot)
            {
                return;
            }

            if (message.Content.Equals("Hello"))
            {
                await message.Channel.SendMessageAsync(string.Format("Hello {0}", user.Mention));
            }

            if (message.Content.Substring(0, 1).Equals("!"))
            {
                string command = message.Content.Replace("!", string.Empty);
                string[] commandList = command.Split(' ');

                if (commandList.Length > 0)
                {
                    if (commandList[0].ToUpper().Equals("지우개") && commandList.Length.Equals(2))
                    {
                        int count;
                        Int32.TryParse(commandList[1], out count);

                        if (count < 1 || count > 100)
                        {
                            await message.Channel.SendMessageAsync("1에서 100 사이의 정수를 입력해야 합니다.");

                            return;
                        }

                        await this.DelMessageAsync(message, count);
                    }
                }
            }
        }

        public async Task DelMessageAsync(SocketMessage pMsg, int pDelCnt)
        {
            var items = await pMsg.Channel.GetMessagesAsync(pDelCnt + 1).Flatten();
            await pMsg.Channel.DeleteMessagesAsync(items);
        }

        private static Task Logger(LogMessage message)
        {
            var cc = Console.ForegroundColor;
            switch (message.Severity)
            {
                case LogSeverity.Critical:
                case LogSeverity.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case LogSeverity.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case LogSeverity.Info:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case LogSeverity.Verbose:
                case LogSeverity.Debug:
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    break;
            }

            if (message.Severity.Equals(LogSeverity.Critical) || message.Severity.Equals(LogSeverity.Error) || message.Severity.Equals(LogSeverity.Warning))
            {
                Console.WriteLine($"{DateTime.Now,-19} [{message.Severity,8}] {message.Source}: {message.Message}");
                Console.WriteLine($"ERROR MESSAGE : {message.Exception.Message}");
            }
            else
            {
                Console.WriteLine($"{DateTime.Now,-19} [{message.Severity,8}] {message.Source}: {message.Message}");
            }

            Console.ForegroundColor = cc;

            // If you get an error saying 'CompletedTask' doesn't exist,
            // your project is targeting .NET 4.5.2 or lower. You'll need
            // to adjust your project's target framework to 4.6 or higher
            // (instructions for this are easily Googled).
            // If you *need* to run on .NET 4.5 for compat/other reasons,
            // the alternative is to 'return Task.Delay(0);' instead.
            return Task.CompletedTask;
        }
    }
}
