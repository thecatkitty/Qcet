using FundacjaBT.EventTool;
using Qcet.Helpers;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Qcet.ViewModels
{
    public class TicketsViewModel : BaseViewModel
    {
        private List<Ticket> allTickets;
        public ObservableCollection<Ticket> Tickets { get; set; }

        public TicketsViewModel()
        {
            Tickets = new ObservableCollection<Ticket>();
        }

        public async Task ShowTicketsAsync()
        {
            App app = Application.Current as App;

            Tickets.Clear();
            allTickets = await app.Api.GetAllTicketsAsync();
            allTickets.ForEach(ticket => Tickets.Add(ticket));
        }

        public void FilterTickets(string pattern)
        {
            Tickets.Clear();
            allTickets
                .Where(ticket
                => ticket.Code == pattern
                || (ticket.PrincipalName?.FullName.MatchesPhrase(pattern) ?? false)
                || (ticket.PrincipalBadge?.Nickname?.MatchesPhrase(pattern) ?? false))
                .ToList()
                .ForEach(ticket => Tickets.Add(ticket));
        }
    }
}
