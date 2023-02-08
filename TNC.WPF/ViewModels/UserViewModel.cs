using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using TNC.WPF.Command;
using TNC.WPF.Data;
using TNC.WPF.Models;

namespace TNC.WPF.ViewModels
{
    public class UserViewModel : ViewModel
    {

        #region Команда CloseApplicationCommand
        public ICommand CloseApplicationCommand { get; set; }

        private bool CanCloseApplicationCommandExecute(object p)
        {
            return true;
        }

        private void OnCloseApplicationCommandExecuteed(object p)
        {
            MessageBox.Show("Приложение закрывается!");
            App.Current.Shutdown();
        }

        #endregion

        public UserViewModel()
        {
            using (DataContext db = new DataContext())
            {
                //Users = db.Users.ToList();
            }

            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuteed, CanCloseApplicationCommandExecute);

        }
    }
}
