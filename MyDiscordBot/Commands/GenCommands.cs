using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharp​Plus.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RiotSharp;
using System.IO;
using Newtonsoft.Json;
using RiotSharp.Misc;
using System.Linq;

namespace MyDiscordBot.Commands
{
    public class GenCommands : BaseCommandModule
    {

        public string riotKey(string uname) {
            var json = string.Empty;
            using (var fs = File.OpenRead("config.json"))
            using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
                json = sr.ReadToEnd();
            var configJson = JsonConvert.DeserializeObject<ConfigJson>(json);
            var myriotKey = configJson.RiotKey;
           // Console.WriteLine("riotkey: "+myriotKey);
            return myriotKey;
                
        }

        [Command("lol")]
        [Description("get riot stuff")]
        public async Task GetRiot(CommandContext ctx, params string[] uname)
        {
            Console.WriteLine(uname.ToString());
            var username = string.Join(" ", uname);
            var api = RiotApi.GetDevelopmentInstance(riotKey(username));

            var summoner = api.Summoner.GetSummonerByNameAsync(Region.Na, username ).Result;
            var name = summoner.Name;
            var level = summoner.Level;
            var accountId = summoner.AccountId;
            await ctx.Channel.SendMessageAsync("Level: "+level.ToString()).ConfigureAwait(false);
        }


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
