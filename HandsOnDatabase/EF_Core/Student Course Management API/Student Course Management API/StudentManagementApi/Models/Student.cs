namespace StudentManagementApi.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public int Age { get; set; }

        public int DepartmentId { get; set; } //Foreign key

        public Department? Department { get; set; } //Navigation prop


        public ICollection<Enrollment> Enrollments { get; set; }
            = new List<Enrollment>();
    }
}
