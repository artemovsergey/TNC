using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskApp.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        string test;


        [RelayCommand]
        void SayText()
        {
            Test = "text1";
        }


        public MainViewModel()
        {
            Test = "test";
        }

    }
}
