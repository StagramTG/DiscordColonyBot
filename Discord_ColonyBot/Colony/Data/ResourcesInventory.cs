using SQLite;

namespace Discord_ColonyBot.Colony.Data
{
    /*
     * Class that represent the colony Resources Inventory
     * Only one entry should exist in the database for this
     * model.
     */
    public class ResourcesInventory
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        
        public int WoodQuantity { get; set; }
        public int StoneQuantity { get; set; }
    }
}