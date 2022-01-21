using SampleXamarinForm.Data;
using SampleXamarinForm.Models;
using SampleXamarinForm.Services;
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
    public partial class ShowEmployeeServicesPage : ContentPage
    {
        private DataAccess _dataAccess;
        private EmployeeServices _empServices;
        public ShowEmployeeServicesPage()
        {
            InitializeComponent();
            _empServices = new EmployeeServices();
            _dataAccess = new DataAccess();
        }

        private async Task GetData()
        {
            var data = await _empServices.GetAll();
            lvEmployees.ItemsSource = data;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                await GetData();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"{ex.Message}", "OK");
            }
        }

        private async void lvEmployees_Refreshing(object sender, EventArgs e)
        {
            await GetData();
            lvEmployees.IsRefreshing = false;
        }

        private async void btnAdd_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddEmployeeServicePage());
        }

        private async void lvEmployees_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var data = (Employee)e.Item;
            EditEmployeeServicePage editPage = new EditEmployeeServicePage();
            editPage.BindingContext = data;
            await Navigation.PushAsync(editPage);
        }

        private void ctxEdit_Clicked(object sender, EventArgs e)
        {
            var data = (MenuItem)sender;
            var employeeId = Convert.ToInt32(data.CommandParameter);
            try
            {
                //var result = 
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void ctxDelete_Clicked(object sender, EventArgs e)
        {

        }
    }
}