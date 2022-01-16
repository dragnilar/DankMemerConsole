using System;
using DevExpress.Mvvm.UI;
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

    public void SendJavaScript(string script)
    {
        WebView2?.CoreWebView2.ExecuteScriptAsync(script);
    }
}