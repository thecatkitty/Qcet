using FundacjaBT.EventTool;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Qcet.ViewModels
{
    public class QueueViewModel : BaseViewModel
    {
        public ObservableCollection<Ticket> Tickets { get; set; }

        public QueueViewModel()
        {
            App app = Application.Current as App;

            Tickets = new ObservableCollection<Ticket>();

            if (app.DisplayServer == null)
            {
                app.DisplayServer = new QueueDisplay.Server(9000, app.Api);
                app.DisplayServer.Start();
            }
        }
        
        public void StartReceiving()
        {
            App app = Application.Current as App;
            app.DisplayServer.Received += Server_Received;
        }

        public void StopReceiving()
        {
            App app = Application.Current as App;
            app.DisplayServer.Received -= Server_Received;
        }

        private void Server_Received(object sender, Ticket ticket)
        {
            Device.BeginInvokeOnMainThread(() => Tickets.Add(ticket));
        }

    }
}
