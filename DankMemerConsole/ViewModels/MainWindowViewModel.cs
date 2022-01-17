using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using DankMemerConsole.Services;
using DevExpress.Mvvm.POCO;
using NLog;
using Tyrrrz.Settings;
using LogLevel = NLog.LogLevel;

namespace DankMemerConsole.ViewModels
{
    public class MainWindowViewModel
    {
        public virtual bool LoggedIntoDiscord { get; set; }
        public virtual string DiscordUserName { get; set; }
        public virtual string DiscordPassword { get; set; }
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
            DiscordUserName = Settings.DiscordUserName;
            DiscordPassword = Settings.DiscordPassword;
            DankChannelUrl = Settings.DankChannelUrl;
        }

        public void LogIntoDiscord()
        {
            WebView2Service.Navigate(!string.IsNullOrWhiteSpace(DankChannelUrl) ? DankChannelUrl : "https://discord.com/channels/@me");
            LoggedIntoDiscord = true;

        }

        public async void Slots()
        {
            try
            {
                await SendMessageToDiscord("pls slots max");
            }
            catch (Exception e)
            {
                nLogger.Log(LogLevel.Error, $"Error running Slots: {e}");
            }

        }

        public async void Beg()
        {
            try
            {
                await SendMessageToDiscord("pls beg");
            }
            catch (Exception e)
            {
                nLogger.Log(LogLevel.Error, $"Error running Beg: {e}");
            }
        }

        public async void Search()
        {
            try
            {
                await SendMessageToDiscord("pls search");
            }
            catch (Exception e)
            {
                nLogger.Log(LogLevel.Error, $"Error running Search: {e}");
            }
        }

        public async void Crime()
        {
            try
            {
                await SendMessageToDiscord("pls crime");
            }
            catch (Exception e)
            {
                nLogger.Log(LogLevel.Error, $"Error running Crime: {e}");
            }
        }

        public async void Fish()
        {
            try
            {
                await SendMessageToDiscord("pls fish");
            }
            catch (Exception e)
            {
                nLogger.Log(LogLevel.Error, $"Error running Fish: {e}");
            }
        }

        public async void Hunt()
        {
            try
            {
                await SendMessageToDiscord("pls hunt");
            }
            catch (Exception e)
            {
                nLogger.Log(LogLevel.Error, $"Error running Hunt: {e}");
            }
        }

        public async void Dig()
        {
            try
            {
                await SendMessageToDiscord("pls dig");
            }
            catch (Exception e)
            {
                nLogger.Log(LogLevel.Error, $"Error running Dig: {e}");
            }
        }

        public async void HighLow()
        {
            try
            {
                await SendMessageToDiscord("pls highlow");
            }
            catch (Exception e)
            {
                nLogger.Log(LogLevel.Error, $"Error running HighLow: {e}");
            }
        }

        public async Task SendMessageToDiscord(string text)
        {
            var result = await WebView2Service.SendDiscordMessage(text);
            nLogger.Log(LogLevel.Info, $"Sent discord message: {text} with result {result}");
        }

        public void OnDiscordUserNameChanged()
        {
            Settings.DiscordUserName = DiscordUserName;
            Settings.Save();
        }

        public void OnDiscordPasswordChanged()
        {
            Settings.DiscordPassword = DiscordPassword;
            Settings.Save();
        }

        public void OnDankChannelUrlChanged()
        {
            Settings.DankChannelUrl = DankChannelUrl;
            Settings.Save();
        }
    }
}
