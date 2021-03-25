namespace Discord_ColonyBot.Colony.Activities
{
    public class ExploreActivity: AbstractActivity
    {
        public ExploreActivity()
        {
            m_baseProduction = 2;
            m_baseMaxDuration = 10;
            m_activityType = ActivityTypes.EXPLORE;
        }
        
        public override Resources.Production Process()
        {
            return new()
            {
                amount = m_baseProduction,
                m_type = m_activityType
            };
        }
    }
}