using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Qcet.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ManualInputView : ContentPage
    {
        public ManualInputView()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if ((codeEntry?.Text ?? "") != "")
            {
                await ScannerView.ShowTicketAsync(this, codeEntry.Text);
            }
        }
    }
}
