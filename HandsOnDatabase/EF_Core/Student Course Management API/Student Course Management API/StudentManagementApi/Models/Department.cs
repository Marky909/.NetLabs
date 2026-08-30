using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace StudentManagementApi.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        [JsonIgnore]
        public ICollection<Student> Students { get; set; }
            = new List<Student>();
    }
}
