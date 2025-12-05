using Microsoft.AspNetCore.Mvc;
using Student_Microservices.Models;
using Student_Microservices.Services;

namespace Student_Microservices.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnrollmentsController : ControllerBase
    {
        private static readonly List<Enrollment> Enrollments = new();
        private readonly CourseServiceClient _courseClient;

        public EnrollmentsController(CourseServiceClient courseClient)
        {
            _courseClient = courseClient;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(Enrollments);

        [HttpPost]
        public async Task<IActionResult> EnrollStudent([FromBody] Enrollment request)
        {
            var course = await _courseClient.GetCourseByIdAsync(request.CourseId);
            if (course == null)
                return NotFound(new { message = $"Course with ID {request.CourseId} not found." });

            var enrollment = new Enrollment
            {
                Id = Enrollments.Count + 1,
                StudentId = request.StudentId,
                StudentName = request.StudentName,
                CourseId = request.CourseId,
                CourseTitle = course.Title
            };

            Enrollments.Add(enrollment);
            return Ok(enrollment);
        }
    }
}
