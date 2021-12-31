using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;
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
        public DankMemerConsoleSettings Settings { get; set; }

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
        }

        public void LogIntoDiscord()
        {
            _driver.Navigate().GoToUrl("https://discord.com/channels/843012305197465604/845591055725625354");
            var userName = _driver.FindElement(By.Name("email"));
            userName.SendKeys(DiscordUserName);
            var password = _driver.FindElement(By.Name("password"));
            password.SendKeys(DiscordPassword);
            var loginButton = _driver.FindElement(By.ClassName("button-3k0cO7"));
            loginButton.Click();
            LoggedIntoDiscord = true;
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
            await Task.Run(() =>
            {
                var textArea = _driver.FindElement(By.XPath("//div[@data-slate-object='block']"));
                textArea.SendKeys(text);
                textArea.SendKeys(Keys.Enter);
            });
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
    }
}
