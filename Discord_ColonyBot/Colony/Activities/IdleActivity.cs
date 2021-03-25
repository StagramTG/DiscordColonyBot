namespace Discord_ColonyBot.Colony.Activities
{
    public class IdleActivity: AbstractActivity
    {
        public IdleActivity()
        {
            m_baseProduction = 0;
            m_baseMaxDuration = 0;
            m_activityType = ActivityTypes.IDLE;
        }
        
        public override Resources.Production Process()
        {
            // Nothing, user is IDLE
            return new()
            {
                amount = m_baseProduction,
                m_type = m_activityType
            };
        }
    }
}