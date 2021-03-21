using System;
using SQLite;

namespace Discord_ColonyBot.Colony.Data
{
    public class DiscordUser
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string UserName { get; set; }
        public string Discriminator { get; set; }
        
        public DateTime RegisteredAt { get; set; }
    }
}