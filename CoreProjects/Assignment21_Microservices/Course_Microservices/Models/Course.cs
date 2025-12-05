namespace Course_Microservices.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Instructor { get; set; } = string.Empty;
        public int Credits { get; set; }
    }
}
