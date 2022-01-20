using Newtonsoft.Json;
using SampleXamarinForm.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SampleXamarinForm.Services
{

    public class EmployeeServices
    {
        private HttpClient _client;

        public EmployeeServices()
        {
            _client = new HttpClient();
        }

        public async Task<List<Employee>> GetAll()
        {
            List<Employee> lstEmployee = new List<Employee>();
            var url = new Uri($"{Helpers.GetServiceUrl.restUrl}/api/Employees");
            try
            {
                var response = await _client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    lstEmployee = JsonConvert.DeserializeObject<List<Employee>>(content);
                }
                return lstEmployee;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task AddEmployee()
        {

        }
    }
}
