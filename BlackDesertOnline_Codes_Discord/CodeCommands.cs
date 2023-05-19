using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.CommandsNext;
using System.Text;

namespace BlackDesertOnline_Codes_Discord
{
    public class CodeCommands:BaseCommandModule
    {

        [Command("codes")]
        public async Task codeCommand(CommandContext ctx)
        {
            StringBuilder sb = new StringBuilder();
            
            foreach (var code in CurrentCodes.current_codes.stored_codes)
            {
                sb.Append(code.code+"\n");
            }
            await ctx.Channel.SendMessageAsync($"{sb.ToString()}");
        }
    }
}
