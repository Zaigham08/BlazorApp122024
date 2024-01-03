using Microsoft.AspNetCore.Mvc;
using BlazorApp122024.Server.Data;
using BlazorApp122024.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp122024.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        AppDbContext _appDbContext;
        public CourseController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        [Route("/Below50")]
        public IEnumerable<Course> GetStudentsBelow50()
        {
            return _appDbContext.Students.Where(x => x.Marks < 50).ToList();
        }

        [HttpGet]
        [Route("/Between50And85")]
        public IEnumerable<Course> GetStudentsBetween50And85()
        {
            return _appDbContext.Students.Where(x => x.Marks >= 50 && x.Marks <= 85).ToList();
        }

        [HttpGet]
        [Route("/Above85")]
        public IEnumerable<Course> GetStudentsAbove85()
        {
            return _appDbContext.Students.Where(x => x.Marks > 85).ToList();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Course course)
        {
            try
            {
                _appDbContext.Students.Add(course);
                _appDbContext.SaveChanges();

                return Ok("Message:Save successfuly");
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}
