using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Http.HttpResults;

namespace EmployeeADO.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string FullName { get; set; } = "";
        public string Department { get; set; } = "";
        public decimal Salary { get; set; }
        public string Email { get; set; } = "";
    }
}
