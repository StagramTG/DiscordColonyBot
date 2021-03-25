namespace Discord_ColonyBot.Colony.Activities
{
    public class GatherWoodActivity: AbstractActivity
    {
        public GatherWoodActivity()
        {
            m_baseProduction = 2;
            m_baseMaxDuration = 10 * 1000;
            m_activityType = ActivityTypes.GATHER_WOOD;
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