using System;
using System.IO;
using System.Threading.Tasks;
using DevExpress.Mvvm.UI;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.Wpf;

namespace DankMemerConsole.Services;

public class WebView2Service : ServiceBase, IWebView2Service
{
    public WebView2 WebView2 => (WebView2) AssociatedObject;
    public void Navigate(string url)
    {
        if (!url.StartsWith("http://") && !url.StartsWith("https://"))
        {
            url = "http://" + url;
        }
        if (Uri.IsWellFormedUriString(url, UriKind.Absolute))
        {
            WebView2?.CoreWebView2.Navigate(url);
        }

    }

    public async Task<string> SendJavaScript(string script)
    {
       var result = await WebView2?.CoreWebView2.ExecuteScriptAsync(script);
       return result;
    }

    public async Task<string> SendDiscordMessage(string message)
    {
        var script = $"api.sendMessage(cid, '{message}')";
        var result = await SendJavaScript(script);
        return result;
    }

    public async Task<string> RegisterSelfBotApi()
    {
        var script = await File.ReadAllTextAsync(Path.Join($"{Environment.CurrentDirectory}", "JS\\DiscordSelfBotAPI.js"));
        var result = await SendJavaScript(script);
        return result;
    }
}