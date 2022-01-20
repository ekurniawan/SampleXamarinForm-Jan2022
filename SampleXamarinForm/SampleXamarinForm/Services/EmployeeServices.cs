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

        public async Task<Employee> GetById(int id)
        {
            Employee employee = new Employee();
            var uri = new Uri($"{Helpers.GetServiceUrl.restUrl}/api/Employees/{id}");
            try
            {
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    employee = JsonConvert.DeserializeObject<Employee>(content);
                }
                return employee;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }

        public async Task AddEmployee(Employee employee)
        {
            var uri = new Uri($"{Helpers.GetServiceUrl.restUrl}/api/Employees");
            try
            {
                var json = JsonConvert.SerializeObject(employee);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _client.PostAsync(uri,content);
                if (!response.IsSuccessStatusCode)
                    throw new Exception("Gagal menambahkan data employee");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }

        public async Task EditEmployee(int id, Employee employee)
        {
            var uri = new Uri($"{Helpers.GetServiceUrl.restUrl}/api/Employees/{id}");
            try
            {
                var json = JsonConvert.SerializeObject(employee);
                var content = new StringContent(json,Encoding.UTF8, "application/json");
                var response = await _client.PutAsync(uri, content);
                if(!response.IsSuccessStatusCode)
                    throw new Exception($"Gagal update data");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }
;
        public async Task DeleteEmployee(int id)
        {
            var uri = new Uri($"{Helpers.GetServiceUrl.restUrl}/api/Employees/{id}");
            try
            {
                var response = await _client.DeleteAsync(uri);
                if (!response.IsSuccessStatusCode)
                    throw new Exception($"Gagal untuk mendelete data {id}");
                
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }
    }
}
