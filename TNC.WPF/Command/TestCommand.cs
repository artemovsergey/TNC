using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace TNC.WPF.Command
{
    public class TestCommand : ICommand
    {

        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object? parameter)
        {
            return 2 > 1;
        }
        public void Execute(object? parameter)
        {
            MessageBox.Show(parameter.ToString());
        }
    }
}
