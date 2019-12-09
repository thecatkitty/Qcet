using FundacjaBT.EventTool;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Qcet
{
    public class TicketSearchViewModel : BaseViewModel
    {
        public ObservableCollection<Ticket> Tickets { get; set; }

        public TicketSearchViewModel()
        {
            Tickets = new ObservableCollection<Ticket>();
        }

        public async Task ShowTicketsAsync()
        {
            App app = Application.Current as App;
            var tickets = await app.Api.GetAllTicketsAsync();
            tickets.ForEach(ticket => Tickets.Add(ticket));
        }
    }
}
