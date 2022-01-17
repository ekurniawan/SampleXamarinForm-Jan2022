using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelloController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get() {
            var arrNama = new List<string>() { "Erick","Peter","Jhon","Tonny","Clark"};

            return arrNama;
        }
    }
}
