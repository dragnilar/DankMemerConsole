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
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using Tyrrrz.Settings;

namespace DankMemerConsole.ViewModels
{
    public class MainWindowViewModel
    {
        public virtual bool LoggedIntoDiscord { get; set; }
        private readonly IWebDriver _driver;
        public virtual string LogText { get; set; }
        public virtual string DiscordUserName { get; set; }
        public virtual string DiscordPassword { get; set; }
        public virtual string DankChannelUrl { get; set; }
        public DankMemerConsoleSettings Settings { get; set; }
        protected virtual IWebView2Service WebView2Service => this.GetService<IWebView2Service>();

        public MainWindowViewModel()
        {
            Settings = new DankMemerConsoleSettings();
            if (File.Exists(Settings.FullFilePath))
            {
                Settings.Load();
            }
            var service = EdgeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;
            _driver = new EdgeDriver(service);

        }

        public void Loaded()
        {
            DiscordUserName = Settings.DiscordUserName;
            DiscordPassword = Settings.DiscordPassword;
            DankChannelUrl = Settings.DankChannelUrl;
        }

        public void LogIntoDiscord()
        {
            WebView2Service.Navigate("https://discord.com/login");
            //var jsText = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "\\JS\\Login.js");
            //WebView2Service.SendJavaScript(jsText);
            LoggedIntoDiscord = true;
            WebView2Service.Navigate(!string.IsNullOrWhiteSpace(DankChannelUrl) ? DankChannelUrl : "https://discord.com/channels/@me");

        }

        public async void Slots()
        {
            try
            {
                await SendTextToBrowser("pls slots max");
            }
            catch (Exception e)
            {
                UpdateLogBox(e.ToString());
            }

        }

        public async void Beg()
        {
            try
            {
                await SendTextToBrowser("pls beg");
            }
            catch (Exception e)
            {
                UpdateLogBox(e.ToString());
            }
        }

        public async void Search()
        {
            try
            {
                await SendTextToBrowser("pls search");
            }
            catch (Exception e)
            {
                UpdateLogBox(e.ToString());
            }
        }

        public async void Crime()
        {
            try
            {
                await SendTextToBrowser("pls crime");
            }
            catch (Exception e)
            {
                UpdateLogBox(e.ToString());
            }
        }

        public async void Fish()
        {
            try
            {
                await SendTextToBrowser("pls fish");
            }
            catch (Exception e)
            {
                UpdateLogBox(e.ToString());
            }
        }

        public async void Hunt()
        {
            try
            {
                await SendTextToBrowser("pls hunt");
            }
            catch (Exception e)
            {
                UpdateLogBox(e.ToString());
            }
        }

        public async void Dig()
        {
            try
            {
                await SendTextToBrowser("pls dig");
            }
            catch (Exception e)
            {
                UpdateLogBox(e.ToString());
            }
        }

        public async void HighLow()
        {
            try
            {
                await SendTextToBrowser("pls highlow");
            }
            catch (Exception e)
            {
                UpdateLogBox(e.ToString());
            }
        }

        public async Task SendTextToBrowser(string text)
        {
            //await Task.Run(() =>
            //{
            //    var textArea = _driver.FindElement(By.XPath("//div[@data-slate-object='block']"));
            //    textArea.SendKeys(text);
            //    textArea.SendKeys(Keys.Enter);
            //});
        }

        public void UpdateLogBox(string message)
        {
            Dispatcher.CurrentDispatcher.Invoke(() =>
            {
                LogText = message;
            });
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
