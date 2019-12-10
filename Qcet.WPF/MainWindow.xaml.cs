using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WPF;

namespace Qcet.WPF
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : FormsApplicationPage
    {
        public MainWindow()
        {
            InitializeComponent();

            Forms.Init();
            Helpers.Platform.Provider = new PlatformProvider();
            LoadApplication(new Qcet.App());
        }
    }
}
