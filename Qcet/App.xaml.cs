﻿using Xamarin.Forms;

namespace Qcet
{
    public partial class App : Application
    {
        public FundacjaBT.EventTool.ApiClient Api { get; set; }
        public QueueDisplay.Client DisplayClient { get; set; }
        public QueueDisplay.Server DisplayServer { get; set; }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Views.MainView())
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
