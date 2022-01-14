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
    public partial class AddEmployeeSQLPage : ContentPage
    {
        private DataAccess _dataAccess;
        public AddEmployeeSQLPage()
        {
            InitializeComponent();
            _dataAccess = new DataAccess();
        }

        private async void btnSubmit_Clicked(object sender, EventArgs e)
        {
            var newEmployee = new Employee
            {
                EmployeeName = txtEmpName.Text,
                Email = txtEmail.Text,
                Qualification = txtQualification.Text,
                Department = txtDepartment.Text
            };

            try
            {
                var result = _dataAccess.InsertEmployee(newEmployee);
                if (result == 1)
                {
                    await DisplayAlert("Info", $"Data employee {newEmployee.EmployeeName} berhasil ditambah", "OK");
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Error", "Gagal menambahkan employee", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"{ex.Message}", "OK");
            }
        }
    }
}