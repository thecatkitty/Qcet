using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Qcet.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScannerView : ZXing.Net.Mobile.Forms.ZXingScannerPage
    {
        public ScannerView()
        {
            InitializeComponent();
        }

        private void ZXingScannerPage_OnScanResult(ZXing.Result result)
        {
            Device.BeginInvokeOnMainThread(async () => await InterpretResultAsync(result));
        }

        private async Task InterpretResultAsync(ZXing.Result result)
        {
            IsScanning = false;

            if (result.BarcodeFormat == ZXing.BarcodeFormat.QR_CODE)
            {
                Match match = Regex.Match(result.Text, @"^[a-zA-Z0-9]+-(?<code>[0-9a-f]+)$");
                if (match.Success)
                {
                    App app = Application.Current as App;

                    var ret = await app.Api.GetTicketsAsync(match.Groups["code"].Value);
                    await Navigation.PushAsync(new TicketView(ret[0]));
                }
            }
        }
    }
}