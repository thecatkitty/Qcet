using FundacjaBT.EventTool;
using System;
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

#if false
            await Ticket.Validate(app.Api);
            Ticket = (await app.Api.GetTicketsAsync(Ticket.Code))[0];
            OnPropertyChanged("Ticket");
#endif
            var queue = new QueueDisplay.Client(app.Api)
            {
                Address = new Uri("http://192.168.1.6:9000/")
            };
            await queue.AddTicketAsync(Ticket);
        }
    }
}
