using Tyrrrz.Settings;

namespace DankMemerConsole;

public class DankMemerConsoleSettings : SettingsManager
{
    public string DankChannelUrl {get; set;}
    public int SlotBetAmount { get; set; } = 1000;
    public int BjBetAmount { get; set; } = 1000;
    public int GambleBetAmount { get; set; } = 1000;
    public int SnakeEyesBetAmount { get; set; } = 1000;
    public int ScratchBetAmount { get; set; } = 1000;
    public int WithDrawAmount { get; set; }
    public int LotteryAmount { get; set; } = 1;
    public int KeyBoardDelay { get; set; } = 100;

    public DankMemerConsoleSettings()
    {
        Configuration.StorageSpace = StorageSpace.Instance;
        Configuration.FileName = "DankMemerConsoleSettings.json";
    }
}