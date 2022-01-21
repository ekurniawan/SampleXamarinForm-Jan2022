using SampleXamarinForm.Data;
using SampleXamarinForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using SampleXamarinForm.Services;

namespace SampleXamarinForm
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShowEmployeeSQLPage : ContentPage
    {
        private EmployeeServices _employeeServices;
        private DataAccess _dataAccess;
        public ShowEmployeeSQLPage()
        {
            InitializeComponent();
            _dataAccess = new DataAccess();
            _employeeServices = new EmployeeServices();
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

        private async void btnSendToServer_Clicked(object sender, EventArgs e)
        {
            var currentConn = Connectivity.NetworkAccess;
            if(currentConn == NetworkAccess.Internet)
            {
                try
                {
                    //ambil semua data dari sqlite
                    var sqliteData = _dataAccess.GetAll().ToList();
                    foreach (var emp in sqliteData)
                    {
                        if (emp.flag == "Red")
                        {
                            //insert data ke server
                            await _employeeServices.AddEmployee(emp);
                            //update flag
                            _dataAccess.UpdateFlag(emp);
                            RefreshData();
                        }
                    }
                    await DisplayAlert("Info", "Local Data uploaded successfuly !", "OK");
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error", $"Error: {ex.Message}", "OK");
                }
            }
            else
            {
                await DisplayAlert("Info", "Tidak ada koneksi internet..", "OK");
            }
        }
    }
}