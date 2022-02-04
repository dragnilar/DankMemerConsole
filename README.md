# DankMemerConsole
This is a windows application for playing Dank Memer on Discord. It provides a number of convienences without going overboard in terms of automation / cheating.

Ever wanted to play Dank Memer with just a mouse?

Well now you can, thanks to this program.

Don't like how the new Discord buttons / interactivity forces you to switch between keyboard and mouse?

Now you can play Dank Memer (almost) entirely with your keyboard thanks to this program.

Need something to keep track of your cooldowns in Dank Memer? This app does that too.

Want a stop watch on screen for the sake of remembering when it's time to stream again? This app has that too.


## Usage

1) Download the program and open it up. The app will generate a cache for its embedded Edge browser, a folder for its settings file and a folder for its log file in the same folder. You should probably put it somewhere that isn't clamped down with security (I.E. Your documents folder is a good place).

2) Enter your Discord Username and Password

3) Click the login to discord button

4) When you are logged into Discord and on your account, go to the channel you normally use for playing Dank Memer.

5) Click the script inject button (necessary) and also click the channel register button so the app remembers which channel to go to the next time you open it.

6) Start playing Dank Memer either using the buttons under the quick commands section or use the text box to enter commands.

7) IF you are using the keyboard method with the text box, you can click buttons that the bot shows using the "click" command. To click a button other than the first one, enter click 2, 3, 4, etc.

8) If a button is not in the first message at the bottom of the message list, you need to enter the index of the message starting from the bottom (I.E. If the message is the second one up from the bottom in the chat, to click the first button in it, enter Click 1 2).

9) When you use one of the "grind" commands for Dank Memer, you'll see the button for it light up red, indicating it is on cooldown. Once the cooldown expires, it will return to its normal state, indicating the cooldown has ended.

## Techologies / Libraries Used

- [WPF (Dot Net 6) for the Windows Application itself](https://docs.microsoft.com/en-us/dotnet/desktop/wpf/overview/?view=netdesktop-6.0)

- [DevExpress' MVVM Framework for MVVM architecture and code simplification](https://github.com/DevExpress/DevExpress.Mvvm.Free)

- [Ghost1372's Unofficial ModernWPF Library](https://github.com/ghost1372/ModernWpf)

- [WebView2 for the embedded Edge Browser](https://developer.microsoft.com/en-us/microsoft-edge/webview2/)

- [JQuery for helping with JavaScript interop](https://github.com/jquery/jquery)

- [Tyrrrz.Settings](https://github.com/Tyrrrz/Settings)

- [Nlog for logging](https://github.com/nlog/NLog/)
  
- [Fluent System Icons For WPF](https://www.nuget.org/packages/FluentSystemIconsForWPF/)


## Known Issues
- The app uses keyboard emulation with the Windows OS to enter messages into Discord. Sometimes Windows moves faster than the app and you can end up with incomplete messages or other odd bugs. This is fairly easy to work around by clicking on Discord and then back in the rest of the app or clearing the message box in Discord and trying again. This is also amplified by the fact that the app uses WebView2 to display Discord inside of it. Microsoft is supposedly working on better keyboard integration with WebView 2, so this may be better resolved in the future.

- The cooldown tracking for the app is not perfect since Dank Memer can lag in responses and/or other occurences. 

- Slash commands are buggy and are not officially supported. You can try using them, but due to the fact that Discord has a slight delay when a slash is entered and before it knows you're using a slash command, a lot of times you'll end up sending a message or getting Discord giving you its "error" shake. 

- Sometimes the script injector button doesn't inject scripts properly when you use it to log into Discord. This is more or less a timing issue with the browser page loading and there really isn't much I can think of to work around it at the moment. The best thing I can suggest is just click the button again if you notice the click commands or the hide sidebar button not working.

- There currently is no way to clear the cache from within the app (although you can clear cookies) without either using the broweser debugger (F12 on your keyboard or inspect element opens it up). Otherwise you will need to delete the cache folder that gets generated in the directory where you put the app.

- I have not tested this app on any OS besides Windows 10/11. It SHOULD work on Windows 7 but I cannot guarantee it. And no, I will not be making a version for Linux or Mac. 

## Privacy Policy

- This app does not explicitly collect any personal information from you or send it anywhere. 

- Please note that Microsoft may collect telemetry and/or diagnostic information from Edge. You should review their privacy policies if you have questions about them.

- Discord may collect information as well and you should obviously use your best judgement when chatting with people on Discord.

