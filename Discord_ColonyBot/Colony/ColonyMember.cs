using System;
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
        
        private ActivityTypes m_currentActivity;
        public ActivityTypes CurrentActivity => m_currentActivity;

        private DateTime m_activityStartedAt;

        public ColonyMember(DiscordUser _discordUser)
        {
            m_discordUser = _discordUser;
            
            m_currentActivity = ActivityTypes.IDLE;
            m_activityStartedAt = DateTime.Now;
        }

        public void UpdateActivity()
        {
            // 
        }

        public void EndCurrentActivity()
        {
            // 
        }

        public void StartActivity()
        {
            // 
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