using SampleXamarinForm.Data;
using SampleXamarinForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
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
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                var location = await Geolocation.GetLocationAsync(request);
                double lat =0.0, lon=0.0; 
                if(location != null)
                {
                    lat = location.Latitude;
                    lon = location.Longitude;
                }

                var newEmployee = new Employee
                {
                    EmployeeName = txtEmpName.Text,
                    Email = txtEmail.Text,
                    Qualification = txtQualification.Text,
                    Department = txtDepartment.Text,
                    flag = "Red",
                    lat = lat,
                    lon = lon
                };

                var result = _dataAccess.InsertEmployee(newEmployee);
                if (result == 1)
                {
                    await DisplayAlert("Info", $"Data employee {newEmployee.EmployeeName} berhasil ditambah, Loc: ({lat},{lon})", "OK");
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Error", "Gagal menambahkan employee", "OK");
                }
            }
            catch(FeatureNotSupportedException fnsEx)
            {
                await DisplayAlert("Error", fnsEx.Message, "OK");
            }
            catch(FeatureNotEnabledException fneEx)
            {
                await DisplayAlert("Error", fneEx.Message, "OK");
            }
            catch (PermissionException pEx)
            {
                await DisplayAlert("Error", pEx.Message, "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"{ex.Message}", "OK");
            }
        }
    }
}