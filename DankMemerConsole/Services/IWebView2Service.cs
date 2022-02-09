using System.Threading.Tasks;
using Microsoft.Web.WebView2.Wpf;

namespace DankMemerConsole.Services;

/// <summary>
/// This service provides various methods for interacting with an instance of a WebView2 / Edge control.
/// Implementations of this service can be used in conjunction with a view model
/// so that the view model can interact with WebView2 without having to hold a direct reference to WebView2.
/// </summary>
public interface IWebView2Service
{
    public WebView2 WebView2 { get; }
    public void Navigate(string url);
    public Task<string> SendJavaScript(string script);
    public Task<string> SendDiscordMessage(string message);
    public Task<string> RegisterScripts();
    public Task<string> HideDiscordSideBar();
    public Task<string> ShowDiscordSideBar();
    public Task ChangeDiscordFont();
    public void FocusDiscord();
    public Task ClickButton(int buttonIndex, int messageIndex = 1);
    public string GetCurrentUrl();
    public bool CanGoForward();
    public bool CanGoBackward();
    public void GoForward();
    public void GoBackward();
    public void Refresh();
    public void OpenBrowserDebugger();
}