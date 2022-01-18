using System;
using System.IO;
using System.Threading.Tasks;
using DankMemerConsole.Services;
using DevExpress.Mvvm.POCO;
using NLog;

namespace DankMemerConsole.ViewModels;

public class MainWindowViewModel
{
    private readonly Logger nLogger = LogManager.GetCurrentClassLogger();

    public MainWindowViewModel()
    {
        Settings = new DankMemerConsoleSettings();
        if (File.Exists(Settings.FullFilePath)) Settings.Load();
    }

    public virtual bool LoggedIntoDiscord { get; set; }
    public virtual string AddressBarUrl { get; set; }
    public DankMemerConsoleSettings Settings { get; set; }
    protected virtual IWebView2Service WebView2Service => this.GetService<IWebView2Service>();

    public void Loaded()
    {
        AddressBarUrl = WebView2Service.GetCurrentUrl();
    }

    public void InjectAPI()
    {
        WebView2Service.Navigate(!string.IsNullOrWhiteSpace(Settings.DankChannelUrl)
            ? Settings.DankChannelUrl
            : "https://discord.com/channels/@me");
        var registerResult = WebView2Service.RegisterSelfBotApi();
        AddressBarUrl = Settings.DankChannelUrl;
        nLogger.Log(LogLevel.Info, $"Attempt to register api result: {registerResult}");
        LoggedIntoDiscord = true;
    }

    public void RegisterChannel()
    {
        var channelRegisterResult = WebView2Service.RegisterChannel();
        Settings.DankChannelUrl = WebView2Service.GetCurrentUrl();
        Settings.Save();
        nLogger.Log(LogLevel.Info, $"Attempt to register channel result: {channelRegisterResult}");
        nLogger.Log(LogLevel.Info, $"Set Dank Channel URL to {Settings.DankChannelUrl}");
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

    public bool CanGoForward()
    {
        return WebView2Service != null && WebView2Service.CanGoForward();
    }

    public void GoForward()
    {
        WebView2Service.GoForward();
    }

    public bool CanGoBackward()
    {
        return WebView2Service != null && WebView2Service.CanGoBackward();
    }

    public void GoBackward()
    {
        WebView2Service.GoBackward();
    }

    public void Refresh()
    {
        WebView2Service.Refresh();
    }

    public void GoHome()
    {
        WebView2Service.Navigate("https://www.discord.com");
        AddressBarUrl = WebView2Service.GetCurrentUrl();
    }

    public async Task SendMessageToDiscord(string text)
    {
        var result = await WebView2Service.SendDiscordMessage(text);
        nLogger.Log(LogLevel.Info, $"Sent discord message: {text} with result {result}");
    }

    public void WebView2Navigate(string url)
    {
        if (string.IsNullOrWhiteSpace(url))
        {
            WebView2Service.Navigate(AddressBarUrl);
        }
        else
        {
            WebView2Service.Navigate(url);
            AddressBarUrl = url;
        }

    }
}