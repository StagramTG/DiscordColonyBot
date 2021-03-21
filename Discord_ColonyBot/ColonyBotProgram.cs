using System;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Discord_ColonyBot.Colony;

namespace Discord_ColonyBot
{
    public class ColonyBotProgram
    {
        private DiscordSocketClient m_discordClient;
        // The bot access token to connect to discord, fetch from discord app panel
        private string m_apiToken = "ODIzMjM4MDQzNzYyNDI1ODU2.YFd6LA.wnxaoP_S6_Qxdfovwkwzvb443g8";

        private CommandService m_commandService;
        private CommandHandler m_commandHandler;
        
        public async Task Run()
        {
            m_discordClient = new DiscordSocketClient();
            m_discordClient.Log += Log;

            await m_discordClient.LoginAsync(TokenType.Bot, m_apiToken);
            await m_discordClient.StartAsync();

            m_commandService = new CommandService();
            m_commandHandler = new CommandHandler(m_discordClient, m_commandService);

            ColonyDatabase.Init();
            await m_commandHandler.InstallCommandsAsync();

            await Task.Delay(-1);
        }

        private Task Log(LogMessage _msg)
        {
            Console.WriteLine(_msg.Message);
            return Task.CompletedTask;
        }
    }
}