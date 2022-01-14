using SampleXamarinForm.Data;
using SampleXamarinForm.Models;
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

        private void RefreshData()
        {
            lvEmployee.ItemsSource = _dataAccess.GetAll();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            RefreshData();
        }

        private async void tbAddEmployee_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddEmployeeSQLPage());
        }

        private void tbTestDate_Clicked(object sender, EventArgs e)
        {
            var currentDate = DateTime.Now;
            var result = currentDate.ToUniversalTime();
            DisplayAlert("Info",result.ToLongTimeString(), "OK");
        }

        private async void lvEmployee_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var editData = (Employee)e.Item;
            EditEmployeeSQLPage editEmployeePage = new EditEmployeeSQLPage();
            editEmployeePage.BindingContext = editData;
            await Navigation.PushAsync(editEmployeePage);
        }

        private async void MenuItem_Clicked(object sender, EventArgs e)
        {
            var data = (MenuItem)sender;
            var confirm = await DisplayAlert("Konfirmasi", "Delete data?", "Yes", "No");
            if (confirm)
            {
                var employeeId = Convert.ToInt32(data.CommandParameter);
                try
                {
                    var delEmployee = new Employee
                    {
                        EmployeeId = employeeId
                    };

                    var result = _dataAccess.DeleteEmployee(delEmployee);
                    if(result==1)
                    {
                        await DisplayAlert("Info","Data berhasil di delete","OK");
                        RefreshData();
                    }
                    else
                    {
                        await DisplayAlert("Error", "Data gagal didelete", "OK");
                    }
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error", $"{ex.Message}", "OK");
                }
            }
        }
    }
}