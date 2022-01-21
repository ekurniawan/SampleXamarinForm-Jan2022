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
    public partial class AddEmployeeServicePage : ContentPage
    {
        private EmployeeServices _employeeServices;
        public AddEmployeeServicePage()
        {
            InitializeComponent();
            _employeeServices = new EmployeeServices();
        }

        private async void btnSubmit_Clicked(object sender, EventArgs e)
        {
            try
            {
                var newEmployee = new Employee
                {
                    EmployeeName = txtEmpName.Text,
                    Email = txtEmail.Text,
                    Qualification = txtQualification.Text,
                    Department = txtDepartment.Text
                };
                await _employeeServices.AddEmployee(newEmployee);
                await DisplayAlert("Info", $"Data employee {newEmployee.EmployeeName} berhasil ditambahkan", "OK");
                await Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Info", $"Error: {ex.Message}", "OK");
            }
        }
    }
}