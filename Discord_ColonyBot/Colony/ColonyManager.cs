using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using Discord_ColonyBot.Colony.Activities;
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
        
        /*
         * Activity dictionnary
         */
        public static readonly Dictionary<string, AbstractActivity> ActivitiesDict =
            new Dictionary<string, AbstractActivity>()
            {
                {"IDLE", new IdleActivity()},
                {"GATHER_WOOD", new GatherWoodActivity()},
                {"GATHER_STONE", new GatherStoneActivity()},
                {"EXPLORE", new ExploreActivity()},
            };
        
        /*
         * Discord Socket Client reference
         */
        private DiscordSocketClient m_discord;

        private ColonyManager()
        {
            m_run = true;
            InitColonyMembers();
        }

        private void InitColonyMembers()
        {
            // Init colony members
            m_members = new List<ColonyMember>();
            DiscordUser[] discordUsers = ColonyDatabase.GetAllUsers();
            foreach (DiscordUser discordUser in discordUsers)
            {
                ColonyMember tmp = new ColonyMember(discordUser);
                m_members.Add(tmp);
            }
        }

        public void GlobalInit(DiscordSocketClient _discord)
        {
            m_discord = _discord;
            Resources.Init();
        }
        
        public async Task Run()
        {
            while (m_run)
            {
                await Task.Delay(1 * 20 * 1000);
                Console.WriteLine(DateTime.Now + " Update started");
                // Evaluate all users Activities
                EvaluateUsersActivities();

                if (m_discord != null)
                {
                    (m_discord.GetChannel(823239084418924595) as ISocketMessageChannel)?.SendMessageAsync(
                        $"```[INFO] Process User production \nWood:  {Resources.WoodQuantity} \nStone: {Resources.StoneQuantity}```");
                }
            }
            
            await Task.CompletedTask;
        }

        private void EvaluateUsersActivities()
        {
            foreach (ColonyMember member in m_members)
            {
                Resources.Production tmp = member.UpdateActivity();
                switch (tmp.m_type)
                {
                    case ActivityTypes.GATHER_WOOD:
                        Resources.AddWood(tmp.amount);
                        break;
                    
                    case ActivityTypes.GATHER_STONE:
                        Resources.AddStone(tmp.amount);
                        break;
                }
            }
            
            Resources.SaveToDatabase();
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