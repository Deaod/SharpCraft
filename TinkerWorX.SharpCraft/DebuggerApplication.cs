﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;

namespace TinkerWorX.SharpCraft
{
    internal class DebuggerApplication : Application
    {
        public static Boolean IsReady { get; private set; }

        public static void Start()
        {
            var thread = new Thread(new ThreadStart(Thread));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private static void Thread()
        {
            try
            {
                var application = new DebuggerApplication();
                var window = new DebuggerWindow();
                DebuggerApplication.IsReady = true;
                application.Run(window);
            }
            catch (Exception exception)
            {
                MessageBox.Show(
                    "Fatal exception!" + Environment.NewLine +
                    exception + Environment.NewLine +
                    "Aborting execution!",
                    typeof(DebuggerApplication) + ".Thread()", MessageBoxButton.OK, MessageBoxImage.Error);
                Process.GetCurrentProcess().Kill();
            }
        }
    }
}
