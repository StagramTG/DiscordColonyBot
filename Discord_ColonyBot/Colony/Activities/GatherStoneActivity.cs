namespace Discord_ColonyBot.Colony.Activities
{
    public class GatherStoneActivity: AbstractActivity
    {
        public GatherStoneActivity()
        {
            m_baseProduction = 2;
            m_baseMaxDuration = 10;
            m_activityType = ActivityTypes.GATHER_STONE;
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