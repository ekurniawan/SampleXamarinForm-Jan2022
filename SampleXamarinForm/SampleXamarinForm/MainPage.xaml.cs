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

            List<string> lstCity = new List<string>() { "Jakarta", "Bandung", "Semarang" };
            pickerCity.ItemsSource = lstCity;
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

        private async void menuCustomList_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CustomListViewPage());
        }

        private async void menuSimpleList_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SimpleListViewPage());
        }

        private void menuAdd_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Keterangan", "Add Data", "OK");
        }

        private async void btnDisplayAlert_Clicked(object sender, EventArgs e)
        {
            var result = await DisplayAlert("Konfirmasi", "Delete data?", "Yes", "No");
            if (result)
            {
                await DisplayAlert("Info", "Anda menjawab Yes", "OK");
            }
            else
            {
                await DisplayAlert("Info", "Anda menjawab No", "OK");
            }
        }

        private async void btnDisplayActionSheet_Clicked(object sender, EventArgs e)
        {
            var result = await DisplayActionSheet("Send To: ?", "Cancel", "Delete", "Whatsapp", "FB", "Instagram");
            await DisplayAlert("Info", $"Anda memilih {result}", "OK");
        }
    }
}
