using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Qcet
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TicketSearchView : ContentPage
    {
        public TicketSearchViewModel ticketSearchViewModel;

        public TicketSearchView()
        {
            InitializeComponent();

            ticketSearchViewModel = new TicketSearchViewModel();
            BindingContext = ticketSearchViewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await ticketSearchViewModel.ShowTicketsAsync();
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}
