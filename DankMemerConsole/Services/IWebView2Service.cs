using System.Threading.Tasks;
using Microsoft.Web.WebView2.Wpf;

namespace DankMemerConsole.Services;

public interface IWebView2Service
{
    public WebView2 WebView2 { get; }
    public void Navigate(string url);
    public Task<string> SendJavaScript(string script);
    public Task<string> SendDiscordMessage(string message);
    public Task<string> RegisterSelfBotApi();
    public Task<string> RegisterChannel();
    public Task<string> RegisterOtherScripts();
    public Task<string> HideDiscordSideBar();
    public Task<string> ShowDiscordSideBar();
    public string GetCurrentUrl();

    public bool CanGoForward();
    public bool CanGoBackward();
    public void GoForward();
    public void GoBackward();
    public void Refresh();
}