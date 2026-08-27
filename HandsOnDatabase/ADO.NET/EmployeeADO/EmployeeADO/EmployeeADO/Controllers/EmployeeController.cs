using Microsoft.AspNetCore.Mvc;
using EmployeeADO.Models;
using Microsoft.Data.SqlClient;

namespace EmployeeADO.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IConfiguration _configuration;

        public EmployeeController(IConfiguration configuration)
        {
            _configuration = configuration; //injection
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<EmployeeModel> list = new List<EmployeeModel>();
            using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            string Query = "SELECT Id,FullName,Department,Salary,Email FROM Employee";
            using SqlCommand command = new SqlCommand(Query, connection);
            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                EmployeeModel employee = new EmployeeModel();
                employee.Id = Convert.ToInt32(reader["Id"]);
                employee.Salary = Convert.ToDecimal(reader["Salary"]);
                employee.FullName = reader["FullName"].ToString() ?? "";
                employee.Email = reader["Email"].ToString() ?? "";
                employee.Department = reader["Department"].ToString() ?? "";

                list.Add(employee);
            }
            return View(list);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(EmployeeModel employee)
        {
            using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            string query = @"INSERT INTO Employee(FullName,Department,Salary,Email) VALUES 
                (@FullName,@Department,@Salary,@Email)";
            connection.Open();
            using SqlCommand command = new(query, connection);
            command.Parameters.AddWithValue("@FullName", employee.FullName); 
            command.Parameters.AddWithValue("@Department", employee.Department); 
            command.Parameters.AddWithValue("@Salary", employee.Salary); 
            command.Parameters.AddWithValue("@Email", employee.Email); 

            command.ExecuteNonQuery();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int id) //details = select
        {
            EmployeeModel? employee = null;
            using  SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            string Query = "SELECT Id,FullName,Department,Salary,Email FROM Employee WHERE Id = @Id";
            using SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@Id", id);
            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                employee = new EmployeeModel(); //Use this when employee was already declared earlier in your code.
                employee.Id = Convert.ToInt32(reader["Id"]);
                employee.Salary = Convert.ToDecimal(reader["Salary"]);
                employee.FullName = reader["FullName"].ToString() ?? "";
                employee.Email = reader["Email"].ToString() ?? "";
                employee.Department = reader["Department"].ToString() ?? "";

            }
            return View(employee);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {

            EmployeeModel? employee = null;
            using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            string Query = "SELECT Id,FullName,Department,Salary,Email FROM Employee WHERE Id = @Id";
            using SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@Id", id);
            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                employee = new EmployeeModel(); //Use this when employee was already declared earlier in your code.
                employee.Id = Convert.ToInt32(reader["Id"]);
                employee.Salary = Convert.ToDecimal(reader["Salary"]);
                employee.FullName = reader["FullName"].ToString() ?? "";
                employee.Email = reader["Email"].ToString() ?? "";
                employee.Department = reader["Department"].ToString() ?? "";

            }
            return View(employee);
        }
        [HttpPost]
        public IActionResult Edit(EmployeeModel employee)
        {
            using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            
            string query = @"UPDATE Employee 
                     SET FullName = @FullName,
                         Department = @Department,
                         Salary = @Salary,
                         Email = @Email 
                     WHERE Id = @Id";

            connection.Open();
            using SqlCommand command = new(query, connection);

            command.Parameters.AddWithValue("@FullName", employee.FullName);
            command.Parameters.AddWithValue("@Department", employee.Department);
            command.Parameters.AddWithValue("@Salary", employee.Salary);
            command.Parameters.AddWithValue("@Email", employee.Email);
            command.Parameters.AddWithValue("@Id", employee.Id);

            command.ExecuteNonQuery();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            string Query = "DELETE FROM Employee WHERE Id = @Id";
            using SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@Id", id);
            connection.Open();
            command.ExecuteNonQuery();

            return RedirectToAction("Index");
        }

    }
}
