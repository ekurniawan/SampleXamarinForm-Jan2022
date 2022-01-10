using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SampleXamarinForm
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnHello_Clicked(object sender, EventArgs e)
        {
            lblHello.Text = entryNama.Text;
        }
    }
}
