using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NZWalks.API.Controllers {
    // https://localhost:7080/api/students
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase {
        // get action method
        // GET: https://localhost:7080/api/students
        [HttpGet]
        public IActionResult GetAllStudents() {
            string[] studentNames = new string[] { "Gabriel", "Letícia", "Roger", "Eduardo", "Rosa" };

            return Ok(studentNames);
        }
    }
}
