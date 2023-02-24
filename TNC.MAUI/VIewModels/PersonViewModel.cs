using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TNC.MAUI.Models;
using TNC.MAUI.Views;
using TNC.WPF.Data;

namespace TNC.MAUI.ViewModels
{
    public class PersonViewModel : ViewModel
    {
        int count = 0;

        #region Свойство TextButton
        private string _textButton;
        public virtual string TextButton
        {
            get { return _textButton; }

            set
            {
                Set(ref _textButton, value);
            }

        }
        #endregion

        #region Свойство PersonName
        private string _personName;
        public virtual string PersonName
        {
            get { return _personName; }

            set
            {
                Set(ref _personName, value);
            }

        }
        #endregion

        #region Свойство PersonAge
        private int _personAge;
        public virtual int PersonAge
        {
            get { return _personAge; }

            set
            {
                Set(ref _personAge, value);
                ((Microsoft.Maui.Controls.Command)AddCommand).ChangeCanExecute();  
            }
        }
        #endregion

        #region Свойство People
        public ObservableCollection<Person> People { get; } = new();
        #endregion

        #region Команда AddCommand
        public ICommand AddCommand { get; set; }
        #endregion

        public ICommand SelectCommand { get; set; }
        public ICommand SwitchToMainPageCommand { get; set; }

        public ICommand BackToTestCommand { get; set; }

        
        public PersonViewModel()
        {
            using (DataContext db = new DataContext())
            {
                //TextButton = db.People.Count().ToString();
            }

            People.Add(new Person() { Name = "user1", Age = 10 });
            People.Add(new Person() { Name = "user2", Age = 11 });
            People.Add(new Person() { Name = "user3", Age = 12 });

            #region AddCommand
            // устанавливаем команду добавления
            AddCommand = new Microsoft.Maui.Controls.Command(
            () =>
            {
                People.Add(new Person() { Name = PersonName, Age = PersonAge });
            },
            () => PersonAge > 2);
            #endregion

            SelectCommand = new Command<Product>(async p =>
            {
                //await DisplayAlert("Notification", $"You have selected: {p.Name}", "ОK");

                await Application.Current.MainPage.DisplayAlert("Notification", $"You have selected: {p.Name}", "ОK");

            });

            SwitchToMainPageCommand = new Command(
                async () => 
                {
                    await Application.Current.MainPage.Navigation.PushAsync(

                        new NavigationPage(new MainPage())
                        {
                            BarBackground = Brush.Yellow,
                            BarBackgroundColor = Color.FromArgb("#2980B9"),
                            BarTextColor = Colors.White
                        }


                        
                     );
                }
                
                );

            BackToTestCommand = new Command(
                async () =>
                {
                await Application.Current.MainPage.Navigation.PopAsync();

                }

                );





        }
    }
}
