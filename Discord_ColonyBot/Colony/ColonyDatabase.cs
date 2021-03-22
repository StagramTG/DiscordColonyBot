using System;
using System.IO;
using System.Linq;
using Discord_ColonyBot.Colony.Data;
using SQLite;

namespace Discord_ColonyBot.Colony
{
    /**
     * Static class that manager the Database.
     */
    public static class ColonyDatabase
    {
        private static string m_assetsDirectoryPath;
        private static string m_databasePath;
        private static SQLiteConnection m_database;
        
        public static bool Init()
        {
            // Create the path to the database file (SQLite)
            m_assetsDirectoryPath = Path.Combine(Environment.CurrentDirectory, "assets");
            m_databasePath = Path.Combine(m_assetsDirectoryPath, "colonyData.db");
            if (!File.Exists(m_databasePath))
            {
                Directory.CreateDirectory(m_assetsDirectoryPath);
                File.Create(m_databasePath);
            }
            
            // Connect to the database
            m_database = new SQLiteConnection(m_databasePath);
            Console.WriteLine("Connected to DB: " + !m_database.Handle.IsClosed);
            
            /*
             * Make sure that all table exists in the database.
             * If it's not the case, create them.
             */
            m_database.CreateTable<DiscordUser>();

            return true;
        }

        public static DiscordUser[] GetAllUsers()
        {
            return m_database.Table<DiscordUser>().ToArray();
        }

        public static DiscordUser GetUser(string _username, string _discriminator)
        {
            if (!m_database.Table<DiscordUser>().Any())
                return null;
            
            Console.WriteLine($"Search for {_username}#{_discriminator} in the DB");
            
            DiscordUser temp = m_database
                .Table<DiscordUser>()
                .First((u) => ((u.UserName == _username) && (u.Discriminator == _discriminator)));

            return temp;
        }

        public static bool InsertDiscordUser(DiscordUser _user)
        {
            int addedCount = m_database.Insert(_user);
            return addedCount > 0;
        }
    }
}