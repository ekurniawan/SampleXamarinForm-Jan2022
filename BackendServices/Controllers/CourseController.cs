using BackendServices.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private List<Course> courses;
        public CourseController()
        {
            courses = new List<Course>
            {
                new Course(){ CourseId=1,Title="ASP Core",Description="ASP Core Course",Price=2000000 },
                new Course(){CourseId=2,Title="Xamarin Forms",Description="Xamarin Forms Course",Price=3000000},
                new Course(){CourseId=3,Title="Blazor Wasm",Description="Blazor Wasm Course",Price=2500000}
            };
        }

        [HttpGet]
        public IEnumerable<Course> Get() {
           
            return courses;
        }

        [HttpGet("{id}")]
        public Course GetById(int id, string title)
        {
            var result = (from c in courses
                          where c.CourseId == id && c.Title.StartsWith("Xamarin")
                          select c).FirstOrDefault();
            return result;
        }

    }
}
