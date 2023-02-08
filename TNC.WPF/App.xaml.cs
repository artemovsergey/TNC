using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace TNC.WPF
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MainWindow mv = new MainWindow();
            //MainWindowViewModel vm = new MainWindowViewModel();
            //mv.DataContext = vm;
            mv.Show();
        }

    }
}
