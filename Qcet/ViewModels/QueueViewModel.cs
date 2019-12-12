using FundacjaBT.EventTool;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Qcet.ViewModels
{
    public class QueueViewModel : BaseViewModel
    {
        public QueueDisplay.Server Server { get; private set; }

        public ObservableCollection<Ticket> Tickets { get; set; }

        public QueueViewModel()
        {
            App app = Application.Current as App;

            Tickets = new ObservableCollection<Ticket>();
            Server = new QueueDisplay.Server(9000, app.Api);
            Server.Received += Server_Received;
        }

        private void Server_Received(object sender, Ticket ticket)
        {
            Device.BeginInvokeOnMainThread(() => Tickets.Add(ticket));
        }

    }
}
