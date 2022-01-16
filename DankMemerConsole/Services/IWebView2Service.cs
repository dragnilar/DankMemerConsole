namespace DankMemerConsole.Services;

public interface IWebView2Service
{
    public void Navigate(string url);
    public void SendJavaScript(string script);
}