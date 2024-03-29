﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Discord;
using Discord.Commands;
using Discord.Net.Providers.WS4Net;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;

namespace LHJ.DiscordBot
{
    public class Program
    {
        private CommandService _Commands;
        private DiscordSocketClient _Client;
        private CommandHandler _CmdHandler;
        private IServiceProvider _Services;

        // Program entry point
        static void Main(string[] args)
        {
            // Call the Program constructor, followed by the 
            // MainAsync method and wait until it finishes (which should be never).
            new Program().MainAsync().GetAwaiter().GetResult();
        }

        private Program()
        {
            this._Client = new DiscordSocketClient(new DiscordSocketConfig
            {
                // How much logging do you want to see?
                LogLevel = LogSeverity.Verbose,

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
            if (Config.bot.token == "" || Config.bot.token == null)
            {
                return;
            }

            this._Commands = new CommandService();
            this._Services = new ServiceCollection()
                        .AddSingleton(this._Client)
                        .AddSingleton(this._Commands)
                        .BuildServiceProvider();

            this._Client.Log += Logger;
            this._Client.Ready += RepeatingTimer.StartTimer;
            this._Client.ReactionAdded += OnReactionAdded;

            this._CmdHandler = new CommandHandler();
            await this._CmdHandler.InitializeAsync(this._Client);

            await this._Client.LoginAsync(TokenType.Bot, Config.bot.token);
            await this._Client.StartAsync();

            Global.Client = this._Client;

            await Task.Delay(-1); // 프로그램 종료시까지 태스크 유지  
        }

        private async Task OnReactionAdded(Cacheable<IUserMessage, ulong> cache, ISocketMessageChannel channel, SocketReaction reaction)
        {
            if (reaction.MessageId == Global.MessageIdToTrack)
            {
                if (reaction.Emote.Name == "👌")
                {
                    if (!reaction.User.Value.IsBot)
                    {
                        await channel.SendMessageAsync(reaction.User.Value.Username + " Says 오키.");
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

                if (message.Exception != null)
                {
                    Console.WriteLine($"ERROR MESSAGE : {message.Exception.Message}");
                }
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
