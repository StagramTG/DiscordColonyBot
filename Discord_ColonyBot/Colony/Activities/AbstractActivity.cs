using System.Diagnostics;

namespace Discord_ColonyBot.Colony.Activities
{
    /**
     * All activities should inherit from this Abstract
     * class
     */
    public abstract class AbstractActivity
    {
        protected int m_baseProduction;
        protected ActivityTypes m_activityType;
        public ActivityTypes ActivityType => m_activityType;

        protected int m_baseMaxDuration;

        public abstract Resources.Production Process();
    }
}