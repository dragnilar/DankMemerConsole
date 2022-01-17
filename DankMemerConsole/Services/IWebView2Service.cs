using System.Threading.Tasks;

namespace DankMemerConsole.Services;

public interface IWebView2Service
{
    public void Navigate(string url);
    public Task<string> SendJavaScript(string script);
    public Task<string> SendDiscordMessage(string message);
    public Task<string> RegisterSelfBotApi();
}