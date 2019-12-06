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
            LoadApplication(new Qcet.App());
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            var topbar = this.Template.FindName("PART_TopAppBar", this) as Xamarin.Forms.Platform.WPF.Controls.FormsAppBar;
            if (topbar != null) topbar.MaxHeight = 0;
        }
    }
}
