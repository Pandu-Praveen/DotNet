using Microsoft.AspNetCore.Mvc;
using Course_Microservices.Models;

namespace Course_Microservices.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase
    {
        private static readonly List<Course> Courses = new()
        {
            new() { Id = 1, Title = "Microservices Architecture", Instructor = "Dr. Allen", Credits = 4 },
            new() { Id = 2, Title = "Cloud Computing", Instructor = "Prof. Smith", Credits = 3 },
            new() { Id = 3, Title = "Data Structures", Instructor = "Dr. Lee", Credits = 4 }
        };

        [HttpGet]
        public IActionResult GetAll() => Ok(Courses);

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var course = Courses.FirstOrDefault(c => c.Id == id);
            if (course == null)
                return NotFound(new { message = $"Course with ID {id} not found." });

            return Ok(course);
        }
    }
}
