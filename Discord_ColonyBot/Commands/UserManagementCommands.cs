using System;
using System.Threading.Tasks;
using Discord.Commands;
using Discord_ColonyBot.Colony;
using Discord_ColonyBot.Colony.Data;

namespace Discord_ColonyBot.Commands
{
    public class UserManagementCommands: ModuleBase<SocketCommandContext>
    {
        [Command("register")]
        [Summary("Register to the colony in order to play.")]
        public Task Register()
        {
            bool isAlreadyRegistered = false;

            DiscordUser user = ColonyDatabase.GetUser(Context.User.Username, Context.User.Discriminator);
            isAlreadyRegistered = (user != null);

            if (isAlreadyRegistered)
            {
                Console.WriteLine("User already registered");
                return ReplyAsync($"{user.UserName} you are already registered in the Colony");
            }

            user = new DiscordUser
            {
                UserName = Context.User.Username,
                Discriminator = Context.User.Discriminator,
                RegisteredAt = DateTime.Now
            };

            Console.WriteLine("Insert the new user in DB");
            ColonyDatabase.InsertDiscordUser(user);

            return ReplyAsync($"{user.UserName}#{user.Discriminator} is now a member of the Colony");
        }

        [Command("ls-users")]
        [Summary("List all registered users")]
        public Task GetRegisteredUser()
        {
            return ReplyAsync("");
        }
    }
}