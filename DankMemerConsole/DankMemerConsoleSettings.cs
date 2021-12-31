using Tyrrrz.Settings;

namespace DankMemerConsole;

public class DankMemerConsoleSettings : SettingsManager
{
    public string DiscordUserName { get; set; }
    public string DiscordPassword { get; set; }

    public DankMemerConsoleSettings()
    {
        Configuration.StorageSpace = StorageSpace.Instance;
        Configuration.FileName = "DankMemerConsoleSettings.json";
    }
}