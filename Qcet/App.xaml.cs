using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Qcet
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage())
            {
                BackgroundColor = Color.Black,
                BarBackgroundColor = Color.FromHex("#702F8A"),
                BarTextColor = Color.White
            };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
