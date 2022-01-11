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

            myImage.Source = ImageSource.FromFile(Path.Combine("images", "monyet1.png"));
        }

        private void BtnSubmit_Clicked(object sender, EventArgs e)
        {
            string result = $"{entryFirstName.Text} - {entryLastName.Text} - {entryEmail.Text}";
            DisplayAlert("Keterangan", result, "OK");
        }
    }
}