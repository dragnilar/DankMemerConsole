using System.Threading.Tasks;

namespace DankMemerConsole.Services;

public interface IWebView2Service
{
    public void Navigate(string url);
    public Task<string> SendJavaScript(string script);
    public Task<string> SendDiscordMessage(string message);
    public Task<string> RegisterSelfBotApi();
    public Task<string> RegisterChannel();
    public string GetCurrentUrl();

    public bool CanGoForward();
    public bool CanGoBackward();
    public void GoForward();
    public void GoBackward();
    public void Refresh();
}