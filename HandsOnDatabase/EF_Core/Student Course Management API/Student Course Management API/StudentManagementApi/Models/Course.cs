namespace StudentManagementApi.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name  { get; set; }

        public int Credit { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
            = new List<Enrollment>();
    }
}
