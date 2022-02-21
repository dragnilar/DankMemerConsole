using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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
using Desktop.Robot;
using Desktop.Robot.Extensions;
using DevExpress.Mvvm;
using ModernWpf.Controls;
using Key = Desktop.Robot.Key;

namespace DankMemerConsole
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Messenger.Default.Register<string>(this, OnTextFocusMessage);
        }

        private void OnTextFocusMessage(string obj)
        {
            if (obj == "FocusTextBoxCommandBox")
            {
                Dispatcher.BeginInvoke(() =>
                {
                    TextBoxCommandBox.Focus();
                });
            }
        }

        private void TestSlashCommand_OnClick(object sender, RoutedEventArgs e)
        {
            var robot = new Robot{AutoDelay = 100};
            WebView2.Focus();
            robot.Type("/"); ;
            robot.Type("whatshard");
            robot.KeyPress(Key.Enter);
            robot.KeyPress(Key.Enter);
            TextBoxCommandBox.Focus();
        }
    }
}