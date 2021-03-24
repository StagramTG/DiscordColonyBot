using System;
using System.IO;
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
        private string m_tokenFilePath;
        private string m_apiToken;

        private CommandService m_commandService;
        private CommandHandler m_commandHandler;
        
        public async Task Run()
        {
            m_discordClient = new DiscordSocketClient();
            m_discordClient.Log += Log;

            m_tokenFilePath = Path.Combine(Environment.CurrentDirectory, "assets", "token.txt");
            m_apiToken = await File.ReadAllTextAsync(m_tokenFilePath);

            await m_discordClient.LoginAsync(TokenType.Bot, m_apiToken);
            await m_discordClient.StartAsync();

            m_commandService = new CommandService();
            m_commandHandler = new CommandHandler(m_discordClient, m_commandService);

            // Database
            ColonyDatabase.Init();
            await m_commandHandler.InstallCommandsAsync();
            
            // ColonyManager init
            ColonyManager.Instance.GlobalInit(m_discordClient);
            await ColonyManager.Instance.Run();

            // await Task.Delay(-1);
        }

        private Task Log(LogMessage _msg)
        {
            Console.WriteLine(_msg.Message);
            return Task.CompletedTask;
        }
    }
}