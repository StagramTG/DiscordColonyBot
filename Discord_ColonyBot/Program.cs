using System;

namespace Discord_ColonyBot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new ColonyBotProgram().Run().GetAwaiter().GetResult();
        }
    }
}