using App.Api.Data;
using App.Api.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private AppDbContext _context;

        public StudentController(AppDbContext dbContext)
        {
            _context = dbContext;
        }

        [HttpGet]
        public IActionResult GetStudents() 
        {
            var students = _context.Students.ToList();

            return Ok(students);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudent([FromRoute]int id)
        {
            var student = _context.Students.SingleOrDefault(x => x.Id == id);

            if(student is null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpPost]
        public IActionResult CreateStudent([FromBody] StudentEntity student)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            student.Id = 0;

            _context.Students.Add(student);

            _context.SaveChanges();

            return Ok(student);
        }
    }
}
