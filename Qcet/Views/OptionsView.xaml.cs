using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Qcet.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OptionsView : ContentPage
    {
        public OptionsView()
        {
            InitializeComponent();
        }

        private void ApplyButton_Clicked(object sender, EventArgs e)
        {
            Settings.DisplayAddress =
                displayUrlEntry.Text == "" ? null : displayUrlEntry.Text;
        }
    }
}