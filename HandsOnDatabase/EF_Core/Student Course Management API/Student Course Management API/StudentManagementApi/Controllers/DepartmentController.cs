using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagementApi.Data;
using StudentManagementApi.Models;

namespace StudentManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DepartmentController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartment()
        {
            return await _context.Departments
                .AsNoTracking()
                .ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetDepartment(int id)
        {
            var department =  await _context.Departments.AsNoTracking().FirstOrDefaultAsync(c=>c.Id==id);
            if (department == null)
                return NotFound();
            return department;
        }

        [HttpPost]
        public async Task<ActionResult<Department>> AddDepartment([FromBody] Department department)
        {
            _context.Departments.Add(department);

            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetDepartment),
                new { id = department.Id },
                department
            );
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Updatedepartment(int id, [FromBody] Department UpdatedDepartment)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department == null)
                return NotFound();
            department.Name = UpdatedDepartment.Name;

            await _context.SaveChangesAsync();
            return NoContent();
            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department == null)
                return NotFound();
            _context.Departments.Remove(department);

            await _context.SaveChangesAsync();
            return NoContent();
        }


    }
}
