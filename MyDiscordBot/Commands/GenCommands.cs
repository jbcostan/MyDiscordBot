using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharp​Plus.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyDiscordBot.Commands
{
    public class GenCommands : BaseCommandModule
    {
        [Command("hi")]
        [Description("hello message")]
        public async Task Salutaion(CommandContext ctx)
        {
            var userName = ctx.User.Username;

            await ctx.Channel.SendMessageAsync("Well hello there "+userName.ToString()).ConfigureAwait(false);
        }

        [Command("add")]
        [Description("adds 2 numbers")]
        public async Task Addition(CommandContext ctx, 
            [Description("1st param/num")]int num1,
            [Description("2nd param/num")]int num2)
        {
            int add = num1 + num2;
            await ctx.Channel.SendMessageAsync(add.ToString()).ConfigureAwait(false);
        }
    }
}
