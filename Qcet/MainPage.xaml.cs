using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace Qcet
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            App app = Application.Current as App;
            if (!app.Api?.IsConnected ?? true)
            {
                Navigation.PushModalAsync(new LogonPage());
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TicketSearchView());
        }
    }
}
