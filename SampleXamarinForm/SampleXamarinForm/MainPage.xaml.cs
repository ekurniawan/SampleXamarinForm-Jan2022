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

        private async void btnGridLayout_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GridLayoutPage(entryNama.Text));
        }

        private void btnGlobalUsername_Clicked(object sender, EventArgs e)
        {
            Global.Instance.username = entryNama.Text;
            DisplayAlert("Keterangan", "Data username sudah disimpan", "OK");
        }
    }
}
