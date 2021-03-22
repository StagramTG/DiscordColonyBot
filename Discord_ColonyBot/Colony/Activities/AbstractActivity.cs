namespace Discord_ColonyBot.Colony.Activities
{
    /**
     * All activities should inherit from this Abstract
     * class
     */
    public abstract class AbstractActivity
    {
        protected int baseProduction;
        protected ActivityTypes m_activityType;

        protected int m_baseMaxDuration;
    }
}