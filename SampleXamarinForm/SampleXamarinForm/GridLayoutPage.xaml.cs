using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleXamarinForm
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GridLayoutPage : ContentPage
    {
        public GridLayoutPage()
        {
            InitializeComponent();
            btnSubmit.Clicked += BtnSubmit_Clicked;

            //myImage.Source = ImageSource.FromFile(Path.Combine("images", "monyet1.png"));

            myImage.Source = 
                ImageSource.FromUri(new Uri("https://i0.wp.com/blog.mzikmund.com/wp-content/uploads/2019/02/microsoft-xamirin-1.jpg"));
        }

        private void BtnSubmit_Clicked(object sender, EventArgs e)
        {
            string result = $"{entryFirstName.Text} - {entryLastName.Text} - {entryEmail.Text}";
            DisplayAlert("Keterangan", result, "OK");
        }

        async private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Image image = (Image)sender;
            await image.FadeTo(0.1, 450);
            await Task.Delay(1000);
            await image.FadeTo(1, 450);
        }

        private async void btnCustomListView_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CustomListViewPage());
        }
    }
}