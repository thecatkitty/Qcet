﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Qcet
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TicketsView : ContentPage
    {
        public TicketsViewModel ticketSearchViewModel;

        public TicketsView()
        {
            InitializeComponent();

            ticketSearchViewModel = new TicketsViewModel();
            BindingContext = ticketSearchViewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            indicator.IsRunning = true;
            statusLabel.Text = "Fetching data...";
            statusLabel.TextColor = Color.Silver;
            statusLabel.IsVisible = true;
            await ticketSearchViewModel.ShowTicketsAsync();

            if (ticketSearchViewModel.Tickets.Count == 0)
            {
                statusLabel.Text = "No tickets.";
                statusLabel.TextColor = Color.Red;
            }
            else
            {
                statusLabel.IsVisible = false;
            }
            indicator.IsRunning = false;
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
