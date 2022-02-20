using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using DankMemerConsole.Properties;
using Desktop.Robot;
using Desktop.Robot.Extensions;
using DevExpress.Mvvm;
using DevExpress.Mvvm.UI;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.Wpf;
using WindowsInput;
using WindowsInput.Native;

namespace DankMemerConsole.Services;

/// <summary>
/// This is a service that provides functionality for interacting with a WebView2 control, it is an implementation of the IWebView2Service.
/// This can be used in conjunction with a view model so that the view model can interact with WebView2 without having to hold a direct reference to WebView2.
/// </summary>
public class WebView2Service : ServiceBase, IWebView2Service
{
    public WebView2 WebView2 => (WebView2) AssociatedObject;
    private InputSimulator InputSimulator = new InputSimulator();

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

    public async Task<string> SendDiscordSlashCommand(string slashCommand)
    {
        var success = false;
        await Dispatcher.InvokeAsync(() =>
        {
            WebView2.Focus();
            if (WebView2.IsFocused)
            {
                var robot = new Robot();
                robot.Type(slashCommand, 100);
            }

            success = true;
        });

        return success ? "Finished" : "Failed";
    }

    public async Task<string> SendSlashCommandPartTwo()
    {
        var success = false;
        await Dispatcher.InvokeAsync(() =>
        {
            WebView2.Focus();
            if (WebView2.IsFocused)
            {
                var robot = new Robot();
                robot.KeyPress(Key.Tab);
                robot.KeyPress(Key.Enter);
            }

            success = true;
        });
        return success ? "Finished" : "Failed";
    }

    public async Task<string> SendDiscordMessage(string message)
    {
        var success = false;
        await Dispatcher.InvokeAsync(() =>
        {
            WebView2.Focus();
            if (WebView2.IsFocused)
            {
                if (string.IsNullOrWhiteSpace(message))
                {
                    InputSimulator.Keyboard.KeyPress(VirtualKeyCode.RETURN);
                }
                else
                {
                    InputSimulator.Keyboard.TextEntry(message).KeyPress(VirtualKeyCode.RETURN);
                }
                success = true;
            }


        });
        return success ? "Finished" : "Failed";

    }

    public async Task<string> RegisterScripts()
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

    public async Task ChangeDiscordFont()
    {
        await SendJavaScript("ChangeDiscordFont()");
    }

    public void FocusDiscord()
    {
        if (!WebView2.IsFocused)
        {
            WebView2.Focus();
        }
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

    public void OpenBrowserDebugger()
    {
        WebView2.CoreWebView2.OpenDevToolsWindow();
    }

    public async Task ClickButton(int buttonIndex, int messageIndex = 1)
    {
        //Buttons are zero based index; if for some reason we type in a 0, we'll just assume you wanted 
        //index zero 
        if (buttonIndex > 0) buttonIndex--;
        //Message indexes start at index 2 from the bottom up in the message list
        if (messageIndex >= 1)
        {
            messageIndex++;
        }
        else
        {
            messageIndex = 2;
        }
 
        

        await SendJavaScript($"ClickButtons({buttonIndex},{messageIndex})");
    }
}