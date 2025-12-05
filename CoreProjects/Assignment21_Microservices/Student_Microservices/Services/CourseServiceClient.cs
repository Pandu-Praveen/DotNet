using System.Net.Http.Json;
using Student_Microservices.Models;

namespace Student_Microservices.Services
{
    public class CourseServiceClient
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<CourseServiceClient> _logger;

        public CourseServiceClient(IHttpClientFactory factory, ILogger<CourseServiceClient> logger)
        {
            _httpClient = factory.CreateClient("CourseService");
            _logger = logger;
        }

        public async Task<Course?> GetCourseByIdAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"/api/courses/{id}");
                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogWarning("Course {Id} not found. Status: {Status}", id, response.StatusCode);
                    return null;
                }

                return await response.Content.ReadFromJsonAsync<Course>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching course ID {Id}", id);
                return null;
            }
        }
    }
}
