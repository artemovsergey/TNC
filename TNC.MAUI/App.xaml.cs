using TNC.MAUI.Views;

namespace TNC.MAUI
{
    public partial class App : Application
    {
        public App(MainPage mainPage)
        {
            InitializeComponent();

            //MainPage = new NavigationPage(new TestPage()); //new MainPage(); 

            MainPage = new NavigationPage(new TestPage())
            {
                BarBackground = Brush.Yellow,
                BarBackgroundColor = Color.FromArgb("#2980B9"),
                BarTextColor = Colors.White
            }; 
        }
    }
}