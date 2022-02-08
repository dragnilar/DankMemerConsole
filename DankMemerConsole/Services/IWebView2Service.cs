using System.Threading.Tasks;
using Microsoft.Web.WebView2.Wpf;

namespace DankMemerConsole.Services;

public interface IWebView2Service
{
    public WebView2 WebView2 { get; }
    public void Navigate(string url);
    public Task<string> SendJavaScript(string script);
    public Task<string> SendDiscordMessage(string message);
    public Task<string> RegisterScripts();
    public Task<string> HideDiscordSideBar();
    public Task<string> ShowDiscordSideBar();
    public void FocusDiscord();
    public Task ClickButton(int buttonIndex, int messageIndex = 1);
    public string GetCurrentUrl();
    public bool CanGoForward();
    public bool CanGoBackward();
    public void GoForward();
    public void GoBackward();
    public void Refresh();
}