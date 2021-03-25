using Discord_ColonyBot.Colony.Data;

namespace Discord_ColonyBot.Colony
{
    public static class Resources
    {
        public struct Production
        {
            public ActivityTypes m_type;
            public int amount;
        }
        
        private static ResourcesInventory m_inventory = ColonyDatabase.GetResourcesInventory();
    }
}