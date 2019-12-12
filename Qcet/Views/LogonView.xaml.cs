using FundacjaBT.EventTool;
using System;
using System.Net.Http;
using System.Security.Authentication;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Qcet.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogonView : ContentPage
    {
        public LogonView()
        {
            InitializeComponent();

            userNameEntry.Completed += (s, e) => passwordEntry.Focus();
            passwordEntry.Completed += (s, e) => loginButton_Clicked(s, e);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            userNameEntry.Focus();
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            layout.Padding = new Thickness(width / 10);
        }

        private void UrlBase_Unfocused(object sender, FocusEventArgs e)
        {
            Settings.ApiAddress = (sender as Entry).Text;
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetButtonState();
        }

        private void passwordEntry_Focused(object sender, FocusEventArgs e)
        {
            passwordEntry.Text = "";
        }

        async void loginButton_Clicked(object sender, EventArgs e)
        {
            App app = Application.Current as App;

            indicator.IsRunning = true;
            statusLabel.TextColor = Color.Silver;

            try
            {
                app.Api = new ApiClient
                {
                    Address = new Uri(Settings.ApiAddress)
                };

                statusLabel.Text = $"Connecting to {app.Api.Address.DnsSafeHost}...";
                var connection = app.Api.Connect(new System.Net.NetworkCredential
                {
                    UserName = userNameEntry.Text,
                    Password = passwordEntry.Text,
                    Domain = app.Api.Address.DnsSafeHost
                });

                await connection;
                connection.Wait();

                if (Settings.DisplayAddress != null)
                {
                    app.DisplayClient = new QueueDisplay.Client(app.Api)
                    {
                        Address = new Uri(Settings.DisplayAddress)
                    };
                    if (!await app.DisplayClient.Detect())
                    {
                        app.DisplayClient = null;
                    }
                }
                Settings.UserName = userNameEntry.Text;
                await Navigation.PopModalAsync();
            }
            catch (AuthenticationException)
            {
                statusLabel.TextColor = Color.Red;
                statusLabel.Text = "Invalid user name or password!";
            }
            catch (HttpRequestException htreqex)
            {
                statusLabel.TextColor = Color.Red;
                statusLabel.Text = $"HTTP error: {htreqex.Message}";
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }

            indicator.IsRunning = false;
            SetButtonState();
        }

        private void SetButtonState()
        {
            App app = Application.Current as App;
            loginButton.IsEnabled =
                !(app.Api?.IsConnected ?? false)
                && ((userNameEntry.Text?.Length ?? 0) > 0)
                && ((passwordEntry.Text?.Length ?? 0) > 0);
        }
    }
}
