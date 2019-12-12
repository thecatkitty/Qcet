using System;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Qcet.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TicketView : ContentPage
    {
        public ViewModels.TicketViewModel ticketViewModel;

        public TicketView(FundacjaBT.EventTool.Ticket ticket)
        {
            InitializeComponent();

            ticketViewModel = new ViewModels.TicketViewModel
            {
                Ticket = ticket
            };
            BindingContext = ticketViewModel;
        }

        private async void validationButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                (sender as Button).IsVisible = false;
                indicator.IsRunning = true;
                await ticketViewModel.Validate();
                indicator.IsRunning = false;
                (sender as Button).IsVisible = true;
            }
            catch (Exception ex)
            {
                indicator.IsRunning = false;
                (sender as Button).IsVisible = true;
                var title = "Error";
                if (ex.GetType() == typeof(HttpRequestException))
                {
                    title = "HTTP Error";
                }

                await DisplayAlert(title, ex.Message, "OK");
            }
        }
    }
}
