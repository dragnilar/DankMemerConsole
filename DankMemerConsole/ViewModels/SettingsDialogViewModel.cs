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
        public object Parameter { get; set; }

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
            SlotBetAmount = App.Settings.SlotBetAmount;
            BjBetAmount = App.Settings.BjBetAmount;
            GambleBetAmount = App.Settings.GambleBetAmount;
            SnakeEyesBetAmount = App.Settings.SnakeEyesBetAmount;
            ScratchBetAmount = App.Settings.ScratchBetAmount;
            WithDrawAmount = App.Settings.WithDrawAmount;
            LotteryAmount = App.Settings.LotteryAmount;
            KeyBoardDelay = App.Settings.KeyBoardDelay;
        }


        /// <summary>
        /// Saves the settings for the program to its json configuration file
        /// </summary>
        public void SaveSettings()
        {
            try
            {
                nLogger.Log(LogLevel.Debug, "Saving settings");
                App.Settings.SlotBetAmount = SlotBetAmount;
                App.Settings.BjBetAmount = BjBetAmount;
                App.Settings.GambleBetAmount = GambleBetAmount;
                App.Settings.SnakeEyesBetAmount = SnakeEyesBetAmount;
                App.Settings.ScratchBetAmount = ScratchBetAmount;
                App.Settings.WithDrawAmount = WithDrawAmount;
                App.Settings.LotteryAmount = LotteryAmount;
                App.Settings.KeyBoardDelay = KeyBoardDelay;
                App.Settings.Save();
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
