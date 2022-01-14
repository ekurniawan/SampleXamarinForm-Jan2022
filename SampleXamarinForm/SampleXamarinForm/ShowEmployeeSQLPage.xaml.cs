using SampleXamarinForm.Data;
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
    public partial class ShowEmployeeSQLPage : ContentPage
    {
        private DataAccess _dataAccess;
        public ShowEmployeeSQLPage()
        {
            InitializeComponent();
            _dataAccess = new DataAccess();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            lvEmployee.ItemsSource = _dataAccess.GetAll();
        }

        private async void tbAddEmployee_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddEmployeeSQLPage());
        }
    }
}