using Tyrrrz.Settings;

namespace DankMemerConsole;

public class DankMemerConsoleSettings : SettingsManager
{
    public string DankChannelUrl {get; set;}

    public DankMemerConsoleSettings()
    {
        Configuration.StorageSpace = StorageSpace.Instance;
        Configuration.FileName = "DankMemerConsoleSettings.json";
    }
}