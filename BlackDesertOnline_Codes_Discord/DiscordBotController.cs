using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackDesertOnline_Codes_Discord
{
    public class DiscordBotController
    {
        public DiscordClient Client { get; private set;}
        public InteractivityExtension Interactivity { get; private set;}
        public CommandsNextExtension CommandsNext { get; private set;}

        public async Task RunAsync()
        {
            var json = String.Empty;
            using (var fs = File.OpenRead("config.json"))
            using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
                json = await sr.ReadToEndAsync();
            var configJson = JsonConvert.DeserializeObject<JsonConfig>(json);
            var config = new DiscordConfiguration()
            {
                Intents = DiscordIntents.All,
                Token = configJson.Token,
                TokenType = TokenType.Bot,
                AutoReconnect = true,
            };

            Client = new DiscordClient(config);
            Client.UseInteractivity(new InteractivityConfiguration()
            {
                Timeout = TimeSpan.FromMinutes(2)
            });

            var commandsConfig = new CommandsNextConfiguration()
            {
                StringPrefixes = new String[] { configJson.Prefix },
                EnableMentionPrefix = true,
                EnableDms = true,
                EnableDefaultHelp = false
            };

            CommandsNext = Client.UseCommandsNext(commandsConfig);
            CommandsNext.RegisterCommands<CodeCommands>();

            await Client.ConnectAsync();
            await Task.Delay(-1);

        }
        private Task onClientReady(ReadyEventArgs e)
        {
            return Task.CompletedTask;
        }
    }
}
