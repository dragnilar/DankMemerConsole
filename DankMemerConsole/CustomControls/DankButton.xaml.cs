using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using DankMemerConsole.Messages;
using DevExpress.Mvvm;
using NLog;

namespace DankMemerConsole.CustomControls
{
    /// <summary>
    /// Interaction logic for DankButton.xaml
    /// </summary>
    public partial class DankButton : Button
    {
        private static Logger nLogger = LogManager.GetCurrentClassLogger();
        private DispatcherTimer _timer;
        private bool _timerRunning;
        private DateTime _timerStart;
        public int CoolDown { get; set; }
        private Brush _originalBackground;
        public DankButton()
        {
            InitializeComponent();
            Messenger.Default.Register<CooldownMessage>(this, OnCoolDownMessage);
        }

        private void OnCoolDownMessage(CooldownMessage obj)
        {
            if (obj.CommandOnCooldownName == Content.ToString() && !_timerRunning)
            {
                StartTimer();
            }
        }

        private void DankButton_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var messageType = "DankMessage";
                var messageContent = Content.ToString();
                Messenger.Default.Send((messageType, messageContent));
                StartTimer();
            }
            catch (Exception exception)
            {
                nLogger.Log(LogLevel.Error, $"Error running {Content}: {exception}");
            }
        }

        private void StartTimer()
        {
            if (!_timerRunning)
            {
                _originalBackground = Background;
                Background = new SolidColorBrush(Color.FromRgb(167, 39, 39));
                _timerStart = DateTime.Now;
                _timer = new DispatcherTimer();
                _timer.Interval = TimeSpan.FromMilliseconds(1);
                _timer.Tick += TimerOnTick;
                _timer.Start();
                _timerRunning = true;
            }

        }

        private void TimerOnTick(object? sender, EventArgs e)
        {
            var elapsedTime = DateTime.Now - _timerStart;
            if (elapsedTime.TotalSeconds >= CoolDown)
            {
                _timer.Stop();
                Background = _originalBackground;
                _timerRunning = false;
            }
        }
    }
}
