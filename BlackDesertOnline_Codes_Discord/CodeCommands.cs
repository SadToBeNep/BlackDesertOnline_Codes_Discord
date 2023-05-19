using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.CommandsNext;
using System.Text;

namespace BlackDesertOnline_Codes_Discord
{
    public class CodeCommands:BaseCommandModule
    {
        /*[Command("test")]
        public async Task testCommand(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("hello");
        }*/

        [Command("codes")]
        public async Task codeCommand(CommandContext ctx)
        {
            Console.Write("XXXXXXXXXXXXXXXXXXXXX");
            StringBuilder sb = new StringBuilder();
            
            foreach (var code in CurrentCodes.current_codes.stored_codes)
            {
                sb.Append(code.code+"\n");
            }
            Console.Write(sb.ToString()+"AAAAAAAAAAAA");
            await ctx.Channel.SendMessageAsync($"{sb.ToString()}");
        }
    }
}
