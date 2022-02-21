﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DankMemerConsole
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static DankMemerConsoleSettings Settings { get; set; }
        protected override void OnStartup(StartupEventArgs e)
        {
            Settings = new DankMemerConsoleSettings();
            if (File.Exists(Settings.FullFilePath)) Settings.Load();
            base.OnStartup(e);
        }
    }
}