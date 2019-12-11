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
    }
}
