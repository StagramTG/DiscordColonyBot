using System.Collections.Generic;
using System.Threading.Tasks;
using Discord_ColonyBot.Colony.Data;

namespace Discord_ColonyBot.Colony
{
    /*
     * The main class that manage game logic and run periodically to process
     * user actions and produce resources based on these actions
     */
    public class ColonyManager
    {
        private bool m_run;
        
        /*
         * Members
         */
        private List<ColonyMember> m_members;
        public int MembersCount => m_members.Count;

        public ColonyManager()
        {
            m_run = true;
            InitColonyMembers();
        }

        private void InitColonyMembers()
        {
            m_members = new List<ColonyMember>();
            DiscordUser[] discordUsers = ColonyDatabase.GetAllUsers();
            foreach (DiscordUser discordUser in discordUsers)
            {
                ColonyMember tmp = new ColonyMember(discordUser);
                m_members.Add(tmp);
            }
        }
        
        public Task Run()
        {
            while (m_run)
            {
                // Evaluate all users Activities
                EvaluateUsersActivities();
                
                Task.Delay(5 * 60 * 1000);
            }
            
            return Task.CompletedTask;
        }

        private void EvaluateUsersActivities()
        {
            foreach (ColonyMember member in m_members)
            {
                member.UpdateActivity();
            }
        }
    }
}