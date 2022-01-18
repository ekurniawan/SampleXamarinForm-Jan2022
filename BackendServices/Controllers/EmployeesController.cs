using BackendServices.DAL;
using BackendServices.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployee _employees;
        public EmployeesController(IEmployee employees)
        {
            _employees = employees;
        }

        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            var results = _employees.GetAll();
            return results;
        }
    }
}
