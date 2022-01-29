using System;
using System.IO;
using System.Threading.Tasks;
using DankMemerConsole.Properties;
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
        var result = await SendJavaScript(Resources.DiscordSelfBotAPI);
        return result;
    }

    public async Task<string> RegisterChannel()
    {
        var result = await SendJavaScript("id();");
        return result;
    }

    public async Task<string> RegisterOtherScripts()
    {
        var getElementByXpathResult = await SendJavaScript(Resources.GetElementsByXPath);
        var toggleSideBarScriptResult = await SendJavaScript(Resources.DiscordFunctions);
        var jQueryRegisterResult = await SendJavaScript(Resources.Jquery);
        return $"{getElementByXpathResult} + {toggleSideBarScriptResult} + {jQueryRegisterResult}";
    }

    public async Task<string> HideDiscordSideBar()
    {
        var result = await SendJavaScript("HideSideBar()");
        return result;
    }

    public async Task<string> ShowDiscordSideBar()
    {
        var result = await SendJavaScript("ShowSideBar()");
        return result;
    }

    public string GetCurrentUrl()
    {
        return WebView2.CoreWebView2 == null ? WebView2.Source.OriginalString : WebView2.CoreWebView2.Source;
    }

    public bool CanGoForward()
    {
        return WebView2 is {CanGoForward: true};
    }

    public bool CanGoBackward()
    {
        return WebView2 is {CanGoBack: true};
    }

    public void GoForward()
    {
        if (CanGoForward()) WebView2.GoForward();
    }

    public void GoBackward()
    {
        if (CanGoBackward()) WebView2.GoBack();
    }

    public void Refresh()
    {
        WebView2?.Reload();
    }

    public async Task ClickButton(int buttonIndex, int messageIndex = 1)
    {
        //Buttons are zero based index; if for some reason we type in a 0, we'll just assume you wanted 
        //index zero 
        if (buttonIndex > 0) buttonIndex--;
        //Message indexes start at index 2 from the bottom up in the message list
        if (messageIndex > 0)
            messageIndex++;
        else
            messageIndex = 2;

        await SendJavaScript($"ClickButtons({buttonIndex},{messageIndex})");
    }
}