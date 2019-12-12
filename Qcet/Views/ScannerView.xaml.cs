using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace Qcet.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScannerView : ContentPage
    {
        public ScannerView()
        {
            InitializeComponent();
        }

        private void RecreateScanner()
        {
            if (scanner != null)
            {
                scanner.IsTorchOn = false;
                scanner.IsAnalyzing = false;
                scanner.IsScanning = false;
                scanner.IsVisible = false;
                scanner.OnScanResult -= scanner_OnScanResult;
                grid.Children.Remove(scanner);
                scanner = null;
            }

            scanner = new ZXingScannerView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                IsScanning = true,
                IsAnalyzing = true
            };
            scanner.OnScanResult += scanner_OnScanResult;
            grid.Children.Insert(0, scanner);
            Grid.SetColumnSpan(scanner, 2);
            Grid.SetRowSpan(scanner, 3);
        }

        private void scanner_OnScanResult(ZXing.Result result)
        {

            Device.BeginInvokeOnMainThread(async () => await InterpretScanResultAsync(result));
        }

        private async void manual_Clicked(object sender, EventArgs e)
        {
            if ((codeEntry?.Text ?? "") != "")
            {
                await ShowTicketAsync(this, codeEntry.Text);
            }
        }

        private async Task InterpretScanResultAsync(ZXing.Result result)
        {
            scanner.IsScanning = false;
            if (result.BarcodeFormat == ZXing.BarcodeFormat.QR_CODE)
            {
                Match match = Regex.Match(result.Text, @"^[a-zA-Z0-9]+-(?<code>[0-9a-f]+)$");
                if (match.Success)
                {

                    indicator.IsRunning = true;
                    await ShowTicketAsync(this, match.Groups["code"].Value);
                    indicator.IsRunning = false;
                }
            }
            scanner.IsScanning = true;

            if (Device.RuntimePlatform == Device.Android)
            {
                RecreateScanner();
            }
        }

        public static async Task ShowTicketAsync(Page page, string code)
        {
            App app = Application.Current as App;

            try
            {
                var ret = await app.Api.GetTicketsAsync(code);
                await page.Navigation.PushAsync(new TicketView(ret[0]));
            }
            catch (Exception ex)
            {
                var title = "Error";
                if (ex.GetType() == typeof(HttpRequestException))
                {
                    title = "HTTP Error";
                }

                await page.DisplayAlert(title, ex.Message, "OK");
            }
        }
    }
}