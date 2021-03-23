using System;
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
        /**
         * Singleton
         */
        private static ColonyManager m_instance = null;

        public static ColonyManager Instance
        {
            get
            {
                if (m_instance == null)
                    m_instance = new ColonyManager();

                return m_instance;
            }
        }
    
        private bool m_run;
        
        /*
         * Members
         */
        private List<ColonyMember> m_members;
        public int MembersCount => m_members.Count;

        private ColonyManager()
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
        
        public async Task Run()
        {
            while (m_run)
            {
                Console.WriteLine(DateTime.Now + " Update started");
                // Evaluate all users Activities
                EvaluateUsersActivities();
                
                await Task.Delay(1 * 60 * 1000);
            }
            
            await Task.CompletedTask;
        }

        private void EvaluateUsersActivities()
        {
            foreach (ColonyMember member in m_members)
            {
                member.UpdateActivity();
            }
        }

        public ColonyMember GetColonyMember(DiscordUser _discordUser)
        {
            foreach (ColonyMember colonyMember in m_members)
            {
                if (colonyMember.IsAttachedTo(_discordUser))
                    return colonyMember;
            }

            return null;
        }
    }
}