using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace LHJ.DiscordBot
{
    public class CommandHandler
    {
        private DiscordSocketClient _Client;
        private CommandService _Service;

        public async Task InitializeAsync(DiscordSocketClient pClient)
        {
            this._Client = pClient;
            this._Service = new CommandService();

            await this._Service.AddModulesAsync(Assembly.GetEntryAssembly());
            this._Client.MessageReceived += HandleCommandAsync;
        }

        [Command(RunMode = RunMode.Async)]
        private async Task HandleCommandAsync(SocketMessage s)
        {
            SocketUserMessage msg = s as SocketUserMessage;

            if (msg == null || msg.Author.IsBot)
            {
                return;
            }

            Global.MessageIdToTrack = msg.Id;

            //// Mute check
            //var userAccount = UserAccounts.GetAccount(context.User);
            //if (userAccount.IsMuted)
            //{
            //    await context.Message.DeleteAsync();
            //    return;
            //}

            //// Leveling up
            //Leveling.UserSentMessage((SocketGuildUser)context.User, (SocketTextChannel)context.Channel);

            int argPos = 0;

            if (msg.HasStringPrefix(Config.bot.cmdPrefix, ref argPos)
                || msg.HasMentionPrefix(this._Client.CurrentUser, ref argPos))
            {
                SocketCommandContext context = new SocketCommandContext(this._Client, msg);
                var result = await this._Service.ExecuteAsync(context, argPos);

                if (!result.IsSuccess && result.Error != CommandError.UnknownCommand)
                {
                    Console.WriteLine(result.ErrorReason);
                }
            }
            else
            {
                if (msg.Content.Equals("오키"))
                {
                    await msg.AddReactionAsync(new Emoji("👌"));
                }

                if (msg.Content.Equals("노랭이"))
                {
                    await msg.Channel.SendMessageAsync("효자네");
                }
            }
        }
    }
}
