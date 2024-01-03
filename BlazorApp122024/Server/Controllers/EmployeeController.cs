using Microsoft.AspNetCore.Mvc;
using BlazorApp122024.Server.Data;
using BlazorApp122024.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp122024.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        AppDbContext _appDbContext;
        public EmployeeController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        [Route("/Pass")]
        public IEnumerable<Employee> GetEmployees()
        {
            return _appDbContext.Employees.ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(Guid id)
        {
            var employee = await _appDbContext.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Employee employee)
        {
            try
            {
                _appDbContext.Employees.Add(employee);
                _appDbContext.SaveChanges();

                return Ok("Message:Save successfuly");
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }

            _appDbContext.Entry(employee).State = EntityState.Modified;

            try
            {
                await _appDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {            
                return NotFound();             
            }

            return NoContent();
        }

    }
}
