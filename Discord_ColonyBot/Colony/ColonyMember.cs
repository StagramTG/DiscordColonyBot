using System;
using Discord_ColonyBot.Colony.Activities;
using Discord_ColonyBot.Colony.Data;

namespace Discord_ColonyBot.Colony
{
    /*
     * Class that represent members of the colony
     * and his current state.
     */
    public class ColonyMember
    {
        private DiscordUser m_discordUser;
        public string UserName => m_discordUser.UserName;
        public string Discriminator => m_discordUser.Discriminator;
        
        private AbstractActivity m_currentActivity;
        public AbstractActivity CurrentActivity => m_currentActivity;

        private DateTime m_activityStartedAt;

        public ColonyMember(DiscordUser _discordUser)
        {
            m_discordUser = _discordUser;
            
            m_currentActivity = ColonyManager.ActivitiesDict["IDLE"];
            m_activityStartedAt = DateTime.Now;
        }

        public Resources.Production UpdateActivity()
        {
            return m_currentActivity.Process();
        }

        public void EndCurrentActivity()
        {
            m_currentActivity =ColonyManager.ActivitiesDict["IDLE"];
        }

        public void StartActivity(string _activity)
        {
            m_currentActivity = ColonyManager.ActivitiesDict[_activity];;
        }

        public bool IsAttachedTo(DiscordUser _discordUser)
        {
            if (m_discordUser.UserName == _discordUser.UserName &&
                m_discordUser.Discriminator == _discordUser.Discriminator)
            {
                return true;
            }

            return false;
        }
    }
}