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

        private async void validationButton_Clicked(object sender, System.EventArgs e)
        {
            try
            {
                indicator.IsVisible = true;
                await ticketViewModel.Validate();
                indicator.IsVisible = false;
            }
            catch (Exception ex)
            {
                indicator.IsVisible = false;
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
