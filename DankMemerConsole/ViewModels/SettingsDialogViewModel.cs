using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using NLog;

namespace DankMemerConsole.ViewModels
{
    /// <summary>
    /// View model for the Dank Memer Console Settings Dialog
    /// </summary>
    public class SettingsDialogViewModel : ISupportParameter
    {
        private static Logger nLogger = LogManager.GetCurrentClassLogger();
        public DankMemerConsoleSettings Settings;
        public virtual int SlotBetAmount { get; set; }
        public virtual int BjBetAmount { get; set; }
        public virtual int GambleBetAmount { get; set; }
        public virtual int SnakeEyesBetAmount { get; set; }
        public virtual int ScratchBetAmount { get; set; }
        public virtual int WithDrawAmount { get; set; }
        public virtual int LotteryAmount { get; set; }
        protected ICurrentWindowService CurrentWindowService => this.GetService<ICurrentWindowService>();

        /// <summary>
        /// Support parameter that accepts a DankMemerConsoleSettings Object
        /// Setting any other type of object will cause a cast exception
        /// </summary>
        public object Parameter
        {
            get => Settings;
            set => Settings = (DankMemerConsoleSettings)value;
        }

        public static SettingsDialogViewModel Create()
        {
            return ViewModelSource.Create(() => new SettingsDialogViewModel());
        }

        protected SettingsDialogViewModel()
        {
        }

        public void Loaded()
        {
            nLogger.Log(LogLevel.Info, "Loaded settings...");
            SlotBetAmount = Settings.SlotBetAmount;
            BjBetAmount = Settings.BjBetAmount;
            GambleBetAmount = Settings.GambleBetAmount;
            SnakeEyesBetAmount = Settings.SnakeEyesBetAmount;
            ScratchBetAmount = Settings.ScratchBetAmount;
            WithDrawAmount = Settings.WithDrawAmount;
            LotteryAmount = Settings.LotteryAmount;
        }


        public void SaveSettings()
        {
            nLogger.Log(LogLevel.Info, "Saving settings");
            Settings.SlotBetAmount = SlotBetAmount;
            Settings.BjBetAmount = BjBetAmount;
            Settings.GambleBetAmount = GambleBetAmount;
            Settings.SnakeEyesBetAmount = SnakeEyesBetAmount;
            Settings.ScratchBetAmount = ScratchBetAmount;
            Settings.WithDrawAmount = WithDrawAmount;
            Settings.LotteryAmount = LotteryAmount;
            Settings.Save();
            CurrentWindowService.Close();
        }



    }
}
