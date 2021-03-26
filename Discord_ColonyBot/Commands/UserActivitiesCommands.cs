using System.Threading.Tasks;
using Discord.Commands;
using Discord_ColonyBot.Colony;
using Discord_ColonyBot.Colony.Data;

namespace Discord_ColonyBot.Commands
{
    public class UserActivitiesCommands: ModuleBase<SocketCommandContext>
    {
        /*
         * Helper to get the Colony member from the Command context.
         */
        private ColonyMember GetMemberFromContext(SocketCommandContext _context)
        {
            DiscordUser currentUser = ColonyDatabase.GetUser(_context.User.Username, _context.User.Discriminator);
            if (currentUser == null)
                return null;
            
            ColonyMember member = ColonyManager.Instance.GetColonyMember(currentUser);
            return member;
        }
        
        [Command("act-current")]
        [Summary("Display your current activity in the colony")]
        public Task UserCurrentActivity()
        {
            ColonyMember member = GetMemberFromContext(Context);
            if (member == null)
                return ReplyAsync("User not found in colony members");

            return ReplyAsync(member.UserName + " you are " + member.CurrentActivity);
        }

        [Command("act-change")]
        [Summary("Change the current activity of the user")]
        public Task ChangeUserCurrentActivity(string _activity)
        {
            ColonyMember member = GetMemberFromContext(Context);
            if (member == null)
                return ReplyAsync("User not found in colony members");

            if (ColonyManager.ActivitiesDict.TryGetValue(_activity, out var selectedActivity))
            {
                member.StartActivity(selectedActivity.ActivityType.ToString());
                return ReplyAsync(member.UserName + " your current activity is now " + selectedActivity.ActivityType);
            }

            return ReplyAsync(member.UserName + " given activity doesn't exist");
        }

        [Command("act-stop")]
        [Summary("Stop the user's current activity")]
        public Task StopUserCurrentActivity()
        {
            ColonyMember member = GetMemberFromContext(Context);
            if (member == null)
                return ReplyAsync("User not found in colony members");

            if (member.CurrentActivity.ActivityType == ActivityTypes.IDLE)
                return ReplyAsync(member.UserName + " your are already IDLE");
            
            member.StartActivity(ActivityTypes.IDLE.ToString());
            
            return ReplyAsync(member.UserName + " your are now IDLE");
        }
    }
}