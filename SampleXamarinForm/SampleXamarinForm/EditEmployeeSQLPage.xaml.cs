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
    public partial class EditEmployeeSQLPage : ContentPage
    {
        private DataAccess _dataAccess; 
        public EditEmployeeSQLPage()
        {
            InitializeComponent();
            _dataAccess = new DataAccess();
        }

        private async void btnSubmit_Clicked(object sender, EventArgs e)
        {
            var editEmp = new Employee
            {
                EmployeeId = Convert.ToInt32(txtEmpID.Text),    
                EmployeeName = txtEmpName.Text,
                Department = txtDepartment.Text,
                Email = txtEmail.Text,
                Qualification = txtQualification.Text,
            };

            try
            {
                var result = _dataAccess.UpdateEmployee(editEmp);
                if (result == 1)
                {
                    await DisplayAlert("Info", $"Data Employee {editEmp.EmployeeId} berhasil diedit", "OK");
                    await Navigation.PopAsync();
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"{ex.Message}", "OK");
            }
        }

        private async void btnDelete_Clicked(object sender, EventArgs e)
        {
            var deleteEmp = new Employee
            {
                EmployeeId = Convert.ToInt32(txtEmpID.Text)
            };

            try
            {
                var confirm = await DisplayAlert("Konfirmasi", "Apakah akan delete data?", "Yes", "No");
                if (confirm)
                {
                    _dataAccess.DeleteEmployee(deleteEmp);
                    await DisplayAlert("Info", "Data berhasil di delete", "OK");
                    await Navigation.PopAsync();
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"{ex.Message}", "OK");
            }
        }
    }
}