using System.Threading.Tasks;
using Discord.Commands;
using Discord_ColonyBot.Colony;
using Discord_ColonyBot.Colony.Data;

namespace Discord_ColonyBot.Commands
{
    public class UserActivitiesCommands: ModuleBase<SocketCommandContext>
    {
        [Command("act-current")]
        [Summary("Display your current activity in the colony")]
        public Task UserCurrentActivity()
        {
            DiscordUser currentUser = ColonyDatabase.GetUser(Context.User.Username, Context.User.Discriminator);
            if (currentUser == null)
                return ReplyAsync(Context.User.Username + " you are not a member of the colony");
            
            // Get the ColonyMember instance attached to this DiscordUser entry
            ColonyMember member = ColonyManager.Instance.GetColonyMember(currentUser);
            if (member == null)
            {
                return ReplyAsync("User not found in colony members");
            }

            return ReplyAsync(currentUser.UserName + " you are " + member.CurrentActivity);
        }
    }
}