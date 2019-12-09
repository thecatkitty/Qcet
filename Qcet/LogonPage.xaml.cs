using FundacjaBT.EventTool;
using System;
using System.Net.Http;
using System.Security.Authentication;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Qcet
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogonPage : ContentPage
    {
        public LogonPage()
        {
            InitializeComponent();
        }

        private void Entry_Unfocused(object sender, FocusEventArgs e)
        {
            Settings.UrlBase = (sender as Entry).Text;
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
                    Address = new Uri(Settings.UrlBase)
                };

                statusLabel.Text = $"Connecting to {app.Api.Address.DnsSafeHost}...";
                var connection = app.Api.Connect(new System.Net.NetworkCredential
                {
                    UserName = loginEntry.Text,
                    Password = passwordEntry.Text,
                    Domain = app.Api.Address.DnsSafeHost
                });

                await connection;
                connection.Wait();
                await Navigation.PopModalAsync();
            }
            catch (AuthenticationException)
            {
                statusLabel.TextColor = Color.Red;
                statusLabel.Text = "Invalid login or password!";
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

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetButtonState();
        }

        private void SetButtonState()
        {
            App app = Application.Current as App;
            loginButton.IsEnabled =
                !(app.Api?.IsConnected ?? false)
                && ((loginEntry.Text?.Length ?? 0) > 0)
                && ((passwordEntry.Text?.Length ?? 0) > 0);
        }
    }
}
