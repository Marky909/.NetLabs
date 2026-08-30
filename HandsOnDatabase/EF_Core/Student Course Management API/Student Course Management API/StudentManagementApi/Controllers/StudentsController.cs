using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagementApi.Data;
using StudentManagementApi.Models;

namespace StudentManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StudentsController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            return await _context.Students
                .Include(x => x.Department)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var student = await _context.Students
                .Include(x => x.Department)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (student == null)
                return NotFound();

            return student;
        }

        [HttpPost]
        public async Task<ActionResult<Student>> AddStudent([FromBody]Student student)
        {
            if (student == null)
                return BadRequest();
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return CreatedAtAction(
                nameof(GetStudent),
                new {id = student.Id},
                student
                );

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] Student updatedStudent)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
                return NotFound();

            student.Name = updatedStudent.Name;
            student.Email = updatedStudent.Email;
            student.Age = updatedStudent.Age;
            student.DepartmentId = updatedStudent.DepartmentId;

            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            _context.Students.Remove(student);

            await _context.SaveChangesAsync();

            return NoContent();


        }
    }
}
