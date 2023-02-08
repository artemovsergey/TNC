using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TNC.WPF.Command;
using TNC.WPF.Data;
using TNC.WPF.Models;

namespace TNC.WPF.ViewModels
{
    public class UserViewModel : ViewModel
    {

        #region Команда AddUserCommand
        public ICommand AddUserCommand { get; set; }

        private bool CanAddUserCommandExecute(object p)
        {
            return true;
        }

        private void OnAddUserCommandExecuteed(object p)
        {
            //CurrentUser = new User();
            //AddUserWindow addUserWindow = new AddUserWindow();
            //addUserWindow.DataContext = this;
            //addUserWindow.ShowDialog();
        }

        #endregion


        #region Свойство Users
        //private IEnumerable<User> _users;
        //public IEnumerable<User> Users
        //{
        //    get { return _users; }

        //    set
        //    {
        //        Set(ref _users, value);
        //    }

        //}
        #endregion

        public UserViewModel()
        {
            using (DataContext db = new DataContext())
            {
                //Users = db.Users.ToList();
            }

            //CurrentUser = new User();
            //CurrentRole = new Role();

            //
            AddUserCommand = new LambdaCommand(OnAddUserCommandExecuteed, CanAddUserCommandExecute);

        }
    }
}
