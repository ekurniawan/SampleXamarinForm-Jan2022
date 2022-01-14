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

        private void btnSubmit_Clicked(object sender, EventArgs e)
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
                
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}