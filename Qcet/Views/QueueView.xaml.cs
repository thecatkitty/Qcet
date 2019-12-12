using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Qcet.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QueueView : ContentPage
    {
        ViewModels.QueueViewModel queueViewModel;

        public QueueView()
        {
            InitializeComponent();

            queueViewModel = new ViewModels.QueueViewModel();
            BindingContext = queueViewModel;
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
    }
}
