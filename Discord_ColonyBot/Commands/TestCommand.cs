using System.Threading.Tasks;
using Discord.Commands;

namespace Discord_ColonyBot.Commands
{
    public class TestCommand: ModuleBase<SocketCommandContext>
    {
        [Command("hello")]
        [Summary("Say hello !")]
        public Task SayHello()
        {
            return ReplyAsync("Hello here !");
        }
    }
}