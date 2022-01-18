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

        [HttpGet("{id}")]
        public ActionResult<Employee> Get(int id)
        {
            var result = _employees.GetById(id);
            if (result == null)
                return NotFound();

            return result;
        }

        [HttpPost]
        public ActionResult Insert(Employee employee)
        {
            try
            {
                _employees.Insert(employee);
                return Ok("Data berhasil ditambahkan");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id,Employee employee)
        {
            try
            {
                _employees.Update(id, employee);
                return Ok($"Data {id} berhasil diupdate");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _employees.Delete(id);
                return Ok($"Delete employee {id} berhasil");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
