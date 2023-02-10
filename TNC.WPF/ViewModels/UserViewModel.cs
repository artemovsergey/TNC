using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using TNC.WPF.Command;
using TNC.WPF.Data;
using TNC.WPF.Infrastucture;
using TNC.WPF.Models;

namespace TNC.WPF.ViewModels
{
    public class UserViewModel : ViewModel
    {

        private string secureCode;
        

        async void disableButton()
        {
            RefreshEnable = false;
            CodeEnable = true;
            LoginEnable = true;
            await Task.Delay(TimeSpan.FromSeconds(10));
            RefreshEnable = true;
            CodeEnable = false;
            LoginEnable = false;
        }


        #region Команда ClearCommand
        public ICommand ClearCommand { get; set; }

        private bool CanClearCommandExecute(object p)
        {
            return true;
        }

        private void OnClearCommandExecuteed(object p)
        {
            
            Number = "";
            (App.Current.MainWindow.FindName("passwordName") as PasswordBox).Password = "";
            Code = "";
            
        }

        #endregion

        #region Команда LoginCommand
        public ICommand LoginCommand { get; set; }

        private bool CanLoginCommandExecute(object p)
        {
            // когда все поля активны
            
            return !(Number == "" && (App.Current.MainWindow.FindName("passwordName") as PasswordBox).Password == "" && Code == "");
        }

        private void OnLoginCommandExecuteed(object p)
        {

            
            using (DataContext db = new DataContext())
            {
                User user = db.Users.Where(u => u.Number == Number).Include(u => u.Role).FirstOrDefault() as User;

                #region Проверка номера сотрудника
                if (user != null)
                {
                    PasswordEnable = true;
                    PasswordFocus = true;
                    
                }
                else
                {
                    MessageBox.Show("Неправильный номер сотрудника");
                    return;
                }
                #endregion


                //MessageBox.Show("Проверка пароля");
                //MessageBox.Show($"Пароль из параметра команды: {((PasswordBox)p).Password}");
                #region Проверка пароля
                
                if (((PasswordBox)p).Password == "")
                {
                    return;
                }

                if (user.Password == ((PasswordBox)p).Password)
                {
                    if (secureCode == null) {
                        // генерация кода доступа
                        secureCode = CodeGeneration.Refresh();//CaptchaBuild.Refresh();
                        // эмуляция СМС
                        MessageBox.Show($"Код: {secureCode}");
                        
                    }

                    disableButton();
                    CodeFocus = true;
                }
                else
                {
                    MessageBox.Show("Неправильный пароль");
                    return;
                }
                #endregion

                #region Проверка кода

                if (Code == null)
                {
                    return;
                }

                if (Code == secureCode)
                {
                    MessageBox.Show($"Здравствуйте, {user.Name}.\nВы: {user.Role.Name}");
                }
                else
                {
                    MessageBox.Show("Неверный код из СМС");
                }
                #endregion

            }




            //MessageBox.Show(user.Role.Name);


        }

        #endregion

        #region Команда RefreshCommand
        public ICommand RefreshCommand { get; set; }

        private bool CanRefreshCommandExecute(object p)
        {
            return true;
        }

        private void OnRefreshCommandExecuteed(object p)
        {
            secureCode = CodeGeneration.Refresh();//CaptchaBuild.Refresh();
            MessageBox.Show($"Код доступа: {secureCode}");
            CodeEnable = true;
            LoginEnable = true;
            
        }

        #endregion



        #region Свойство Number
        private string _number;
        public virtual string Number
        {
            get { return _number; }

            set
            {
                Set(ref _number, value);
            }

        }
        #endregion

        #region Свойство PasswordEnable
        private bool _passwordEnable;
        public virtual bool PasswordEnable
        {
            get { return _passwordEnable; }

            set
            {
                Set(ref _passwordEnable, value);
            }

        }
        #endregion

        #region Свойство Code
        private string _code;
        public virtual string Code
        {
            get { return _code; }

            set
            {
                Set(ref _code, value);
            }

        }
        #endregion

        #region Свойство CodeEnable
        private bool _codeEnable;
        public virtual bool CodeEnable
        {
            get { return _codeEnable; }

            set
            {
                Set(ref _codeEnable, value);
            }

        }
        #endregion
        
        #region Свойство CodeFocus
        private bool _codeFocus;
        public virtual bool CodeFocus
        {
            get { return _codeFocus; }

            set
            {
                Set(ref _codeFocus, value);
            }

        }
        #endregion

        #region Свойство LoginEnable
        private bool _loginEnable;
        public virtual bool LoginEnable
        {
            get { return _loginEnable; }

            set
            {
                Set(ref _loginEnable, value);
            }

        }
        #endregion

        #region Свойство RefreshEnable
        private bool _refreshEnable;
        public virtual bool RefreshEnable
        {
            get { return _refreshEnable; }

            set
            {
                Set(ref _refreshEnable, value);
            }

        }
        #endregion

        #region Свойство PasswordFocus
        private bool _passwordFocus;
        public virtual bool PasswordFocus
        {
            get { return _passwordFocus; }

            set
            {
                Set(ref _passwordFocus, value);
            }

        }
        #endregion


        public UserViewModel()
        {
            PasswordEnable = false;
            PasswordEnable = false;
            CodeEnable = false;
            LoginEnable = false;
            RefreshEnable = false;
            
            ClearCommand = new LambdaCommand(OnClearCommandExecuteed, CanClearCommandExecute);
            LoginCommand = new LambdaCommand(OnLoginCommandExecuteed, CanLoginCommandExecute);
            RefreshCommand = new LambdaCommand(OnRefreshCommandExecuteed, CanRefreshCommandExecute);
        }
    }
}
