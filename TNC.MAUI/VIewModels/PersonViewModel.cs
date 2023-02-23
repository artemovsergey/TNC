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

        
        public PersonViewModel()
        {
            using (DataContext db = new DataContext())
            {
                //TextButton = db.People.Count().ToString();
            }



            #region AddCommand
            // устанавливаем команду добавления
            AddCommand = new Microsoft.Maui.Controls.Command(
            () =>
            {
                People.Add(new Person() { Name = PersonName, Age = PersonAge });
            },
            () => PersonAge > 2); 
            #endregion





        }
    }
}
