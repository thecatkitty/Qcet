using FundacjaBT.EventTool;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Qcet.ViewModels
{
    public class TicketViewModel : BaseViewModel
    {
        public Ticket Ticket { get; set; }

        public TicketViewModel()
        {
        }

        public async Task Validate()
        {
            App app = Application.Current as App;

            await Ticket.Validate(app.Api);
            Ticket = (await app.Api.GetTicketsAsync(Ticket.Code))[0];
            OnPropertyChanged("Ticket");
        }
    }
}
