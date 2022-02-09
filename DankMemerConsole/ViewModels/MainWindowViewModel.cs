using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;
using DankMemerConsole.Constants;
using DankMemerConsole.Messages;
using DankMemerConsole.Services;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using NLog;

namespace DankMemerConsole.ViewModels;

/// <summary>
/// View model for the main window in the program, the majority of application functionality passes through this view model
/// </summary>
public class MainWindowViewModel
{
    private readonly Logger nLogger = LogManager.GetCurrentClassLogger();
    private bool _Loading;
    private bool _timerRunning;
    private DateTime _timerStart;
    private DispatcherTimer _timer;
    public virtual bool SideBarVisible { get; set; }

    public MainWindowViewModel()
    {
        Settings = new DankMemerConsoleSettings();
        if (File.Exists(Settings.FullFilePath)) Settings.Load();
    }

    public virtual bool LoggedIntoDiscord { get; set; }
    public virtual string CommandText { get; set; }
    public virtual string TimerValue { get; set; }
    public DankMemerConsoleSettings Settings { get; set; }
    protected virtual IWebView2Service WebView2Service => this.GetService<IWebView2Service>();

    public void Loaded()
    {
        _Loading = true;
        SideBarVisible = true;
        TimerValue = "No Timer Running";
        _Loading = false;
        Messenger.Default.Register<Tuple<string, string>>(this, OnDankMessage);
    }

    private void OnDankMessage(Tuple<string, string> obj)
    {
        if (obj.Item1 == "DankMessage")
        {
            SendDankMessage(obj.Item2);
        }
    }

    public void InjectScripts()
    {
        if (!LoggedIntoDiscord)
        {
            WebView2Service.Navigate(!string.IsNullOrWhiteSpace(Settings.DankChannelUrl)
                ? Settings.DankChannelUrl
                : "https://discord.com/channels/@me");
        }
        var registerOtherScriptsResult = WebView2Service.RegisterScripts();
        nLogger.Log(LogLevel.Debug, $"Attempt to register scripts result: {registerOtherScriptsResult}");
        LoggedIntoDiscord = true;
    }

    public void RegisterChannel()
    {
        Settings.DankChannelUrl = WebView2Service.GetCurrentUrl();
        Settings.Save();
        nLogger.Log(LogLevel.Debug, $"Set Dank Channel URL to {Settings.DankChannelUrl}");
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
        var result = await WebView2Service.SendDiscordMessage(text).ConfigureAwait(false);
        nLogger.Log(LogLevel.Info, $"Sent discord message: {text} with result {result}");
        if (result.ToLower() == "finished")
        {
            Thread.Sleep(Settings.KeyBoardDelay);
            FocusTextBox();
        }
    }

    public void OnSideBarVisibleChanged()
    {
        if (_Loading) return;
        if (SideBarVisible)
        {
            WebView2Service.ShowDiscordSideBar();
        }
        else
        {
            WebView2Service.HideDiscordSideBar();

        }
    }

    public void ShowSettings()
    {
        var service = this.GetRequiredService<IWindowService>();
        var vm = SettingsDialogViewModel.Create();
        service.Title = "Settings";
        service.Show(null, vm, Settings, this);
    }

    public async Task SendTextBoxMessage()
    {
        if (CommandText.ToLower().StartsWith("click"))
        {
            var commandTextArray = CommandText.Split(" ");
            if (commandTextArray.Length >= 2 && int.TryParse(commandTextArray[1], out var intResult))
            {
                if (commandTextArray.Length >= 3 && int.TryParse(commandTextArray[2], out var messageIndexResult))
                    await WebView2Service.ClickButton(intResult, messageIndexResult);

                await WebView2Service.ClickButton(intResult);
            }
            else
            {
                await WebView2Service.ClickButton(1);
            }
        }
        else
        {
            await SendMessageToDiscord(CommandText);
        }

        if (CoolDownCommandNames.CommandNames.Contains(CommandText))
        {
            Messenger.Default.Send(new CooldownMessage(CommandText));
        }

        CommandText = string.Empty;
    }

    public async Task Gamble(string command)
    {
        string commandText;
        switch (command)
        {
            case "bet":
                commandText = $"pls bet {Settings.GambleBetAmount}";
                break;
            case "se":
                commandText = $"pls se {Settings.SnakeEyesBetAmount}";
                break;
            case "bj":
                commandText = $"pls bj {Settings.BjBetAmount}";
                break;
            case "scratch":
                commandText = $"pls scratch {Settings.ScratchBetAmount}";
                break;
            case "slots":
                commandText = $"pls slots {Settings.SlotBetAmount}";
                break;
            case "lotto":
                commandText = $"pls lotto {Settings.LotteryAmount}";
                break;
            default:
                commandText = $"pls bet {Settings.GambleBetAmount}";
                break;

        }

        await SendMessageToDiscord(commandText);
    }

    public async void StartTimer()
    {
        if (!_timerRunning)
        {
            _timerStart = DateTime.Now;
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromMilliseconds(1);
            _timer.Tick += Timer_Tick;
            _timer.Start();
            _timerRunning = true;
        }
        else
        {
            _timer.Stop();
            _timerRunning = false;
            TimerValue = "No Timer Running";
        }


    }

    private void Timer_Tick(object sender, EventArgs e)
    {
        var elapsedTime = DateTime.Now - _timerStart;
        TimerValue = $"Elapsed: {elapsedTime.ToString("hh\\:mm\\:ss")} - Started: {_timerStart.ToString("HH:mm:ss tt")}";

    }

    public async Task Withdraw() => await SendMessageToDiscord(Settings.WithDrawAmount == 0 ? "pls with max" : $"pls with {Settings.WithDrawAmount}");
    public void FocusTextBox() =>         Messenger.Default.Send("FocusTextBoxCommandBox");
    public void FocusWebView2() =>        WebView2Service.FocusDiscord();
    public async void ChangeDiscordFont() =>         await WebView2Service.ChangeDiscordFont();
    public void Refresh() =>         WebView2Service.Refresh();
    public void ShowDebugger() => WebView2Service.OpenBrowserDebugger();
}