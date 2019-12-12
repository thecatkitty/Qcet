using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace Qcet.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainView : ContentPage
    {
        public MainView()
        {
            InitializeComponent();

            App app = Application.Current as App;
            if (!app.Api?.IsConnected ?? true)
            {
                Navigation.PushModalAsync(new LogonView());
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        private void ShowAll_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TicketsView());
        }

        private void Scan_Clicked(object sender, EventArgs e)
        {
            if (Device.RuntimePlatform == Device.WPF)
            {
                Navigation.PushAsync(new ManualInputView());
            }
            else
            {
                Navigation.PushAsync(new ScannerView());
            }
        }

        private void Queue_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new QueueView());
        }
    }
}
