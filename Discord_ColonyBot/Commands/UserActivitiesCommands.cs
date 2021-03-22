using System.Threading.Tasks;
using Discord.Commands;
using Discord_ColonyBot.Colony;
using Discord_ColonyBot.Colony.Data;

namespace Discord_ColonyBot.Commands
{
    public class UserActivitiesCommands: ModuleBase<SocketCommandContext>
    {
        public Task UserCurrentActivity()
        {
            DiscordUser currentUser = ColonyDatabase.GetUser(Context.User.Username, Context.User.Discriminator);
            if (currentUser == null)
                return ReplyAsync(Context.User.Username + " you are not a member of the colony");
            
            // Get the ColonyMember instance attached to this DiscordUser entry
            

            return ReplyAsync(currentUser.UserName + " you are ");
        }
    }
}