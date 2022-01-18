using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using DankMemerConsole.Services;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using NLog;
using Tyrrrz.Settings;
using LogLevel = NLog.LogLevel;

namespace DankMemerConsole.ViewModels
{
    public class MainWindowViewModel
    {
        public virtual bool LoggedIntoDiscord { get; set; }
        public virtual string DankChannelUrl { get; set; }
        public DankMemerConsoleSettings Settings { get; set; }
        protected virtual IWebView2Service WebView2Service => this.GetService<IWebView2Service>();
        private Logger nLogger = LogManager.GetCurrentClassLogger();

        public MainWindowViewModel()
        {
            Settings = new DankMemerConsoleSettings();
            if (File.Exists(Settings.FullFilePath))
            {
                Settings.Load();
            }
        }

        public void Loaded()
        {
            DankChannelUrl = Settings.DankChannelUrl;
        }

        public void InjectAPI()
        {
            WebView2Service.Navigate(!string.IsNullOrWhiteSpace(DankChannelUrl) ? DankChannelUrl : "https://discord.com/channels/@me");
            var registerResult = WebView2Service.RegisterSelfBotApi();
            nLogger.Log(LogLevel.Info, $"Attempt to register api result: {registerResult}");
            LoggedIntoDiscord = true;

        }

        public void RegisterChannel()
        {
            var channelRegisterResult = WebView2Service.RegisterChannel();
            DankChannelUrl = WebView2Service.GetCurrentUrl();
            Settings.DankChannelUrl = DankChannelUrl;
            Settings.Save();
            nLogger.Log(LogLevel.Info, $"Attempt to register channel result: {channelRegisterResult}");
            nLogger.Log(LogLevel.Info, $"Set Dank Channel URL to {DankChannelUrl}");
        }

        public async void SendDankMessage(string commandText)
        {
            try
            {
                await SendMessageToDiscord(commandText);
            }
            catch (Exception e)
            {
                nLogger.Log(LogLevel.Error, $"Error running {commandText}: {e}");
            }
        }

        public async Task SendMessageToDiscord(string text)
        {
            var result = await WebView2Service.SendDiscordMessage(text);
            nLogger.Log(LogLevel.Info, $"Sent discord message: {text} with result {result}");
        }
    }
}
