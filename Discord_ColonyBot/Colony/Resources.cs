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
        
        private static ResourcesInventory m_inventory;

        public static int WoodQuantity => m_inventory.WoodQuantity;
        public static int StoneQuantity => m_inventory.StoneQuantity;

        public static void Init()
        {
            m_inventory = ColonyDatabase.GetResourcesInventory();
        }

        public static void AddWood(int amount)
        {
            m_inventory.WoodQuantity += amount;
        }
        
        public static void AddStone(int amount)
        {
            m_inventory.StoneQuantity += amount;
        }
        
        public static void SaveToDatabase()
        {
            ColonyDatabase.UpdateResourcesInventory(m_inventory);
        }
    }
}