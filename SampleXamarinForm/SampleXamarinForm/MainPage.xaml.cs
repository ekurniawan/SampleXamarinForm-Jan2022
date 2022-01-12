using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace SampleXamarinForm
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            if (Preferences.ContainsKey("language"))
            {
                entryLanguage.Text = Preferences.Get("language", "");
            }
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

        private void btnSetPreference_Clicked(object sender, EventArgs e)
        {
            Preferences.Set("language", entryLanguage.Text);   
        }
    }
}
