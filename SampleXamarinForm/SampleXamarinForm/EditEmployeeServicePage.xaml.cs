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
    public partial class EditEmployeeServicePage : ContentPage
    {
        private EmployeeServices _employeeServices; 
        public EditEmployeeServicePage()
        {
            InitializeComponent();
            _employeeServices = new EmployeeServices();
        }

        private async void btnEdit_Clicked(object sender, EventArgs e)
        {
            try
            {
                var editEmp = new Employee
                {
                    EmployeeName = txtEmpName.Text,
                    Email = txtEmail.Text,
                    Qualification = txtQualification.Text,
                    Department = txtDepartment.Text
                };
                await _employeeServices.EditEmployee(Convert.ToInt32(txtEmpID.Text), editEmp);
                await DisplayAlert("Info", $"Data Employee berhasil diupdate", "OK");
                await Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Info", $"Error: {ex.Message}", "OK");
            }
        }        
    }
}