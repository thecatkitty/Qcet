using FundacjaBT.EventTool;
using Plugin.SimpleAudioPlayer;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Qcet.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QueueView : ContentPage
    {
        ViewModels.QueueViewModel queueViewModel;
        private ISimpleAudioPlayer newTicketSound;

        public QueueView()
        {
            InitializeComponent();

            queueViewModel = new ViewModels.QueueViewModel();
            BindingContext = queueViewModel;
            
            newTicketSound = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            newTicketSound.Load(
                GetType().Assembly.GetManifestResourceStream("Qcet.Media.NewTicket.mp3"));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            queueViewModel.StartReceiving();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            queueViewModel.StopReceiving();
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (await DisplayAlert(
                "Confirmation",
                "Press OK if you've finished your activity related to this attendant.",
                "OK", "Cancel"))
            {
                queueViewModel.Tickets.Remove(e.Item as Ticket);
            }
        }

        private void ListView_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            newTicketSound.Play();
        }
    }
}
