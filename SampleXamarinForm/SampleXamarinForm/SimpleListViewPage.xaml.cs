using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleXamarinForm
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SimpleListViewPage : ContentPage
    {
        public SimpleListViewPage()
        {
            InitializeComponent();
            List<string> items = new List<string>() { "CSharp","VB","Java","Golang","ASP Core" };
            lvData.ItemsSource = items;
        }

        private void lvData_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item.ToString();
            DisplayAlert("Item", item + " dipilih", "OK");
            ((ListView)sender).SelectedItem = null;
        }
    }
}