using System;
using System.Windows.Input;
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
        public virtual int KeyBoardDelay { get; set; }
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

        /// <summary>
        /// Creates an instance of the view model, used for setting the view model on dependent services in parent view model.
        /// </summary>
        /// <returns>Instance of the SettingsDialog View Model</returns>
        public static SettingsDialogViewModel Create()
        {
            return ViewModelSource.Create(() => new SettingsDialogViewModel());
        }

        protected SettingsDialogViewModel()
        {
        }

        /// <summary>
        /// Used when the view is loaded to set the settings on the view models' properties
        /// </summary>
        public void Loaded()
        {
            SlotBetAmount = Settings.SlotBetAmount;
            BjBetAmount = Settings.BjBetAmount;
            GambleBetAmount = Settings.GambleBetAmount;
            SnakeEyesBetAmount = Settings.SnakeEyesBetAmount;
            ScratchBetAmount = Settings.ScratchBetAmount;
            WithDrawAmount = Settings.WithDrawAmount;
            LotteryAmount = Settings.LotteryAmount;
            KeyBoardDelay = Settings.KeyBoardDelay;
        }


        /// <summary>
        /// Saves the settings for the program to its json configuration file
        /// </summary>
        public void SaveSettings()
        {
            try
            {
                nLogger.Log(LogLevel.Debug, "Saving settings");
                Settings.SlotBetAmount = SlotBetAmount;
                Settings.BjBetAmount = BjBetAmount;
                Settings.GambleBetAmount = GambleBetAmount;
                Settings.SnakeEyesBetAmount = SnakeEyesBetAmount;
                Settings.ScratchBetAmount = ScratchBetAmount;
                Settings.WithDrawAmount = WithDrawAmount;
                Settings.LotteryAmount = LotteryAmount;
                Settings.KeyBoardDelay = KeyBoardDelay;
                Settings.Save();
                CurrentWindowService.Close();
            }
            // ReSharper disable once CatchAllClause - too many possible I/O exceptions and/or potential DevExpress errors
            catch (Exception e)
            {
                nLogger.Log(LogLevel.Error, $"Error saving settings: {e}");
            }
        }



    }
}
