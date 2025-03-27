using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_API_task1.DTO;
using Web_API_task1.Models;

namespace Web_API_task1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        ITIentity context = new ITIentity();

        [HttpGet]
        public IActionResult Get()
        {
            List<Student> student = context.Students.Include(e => e.Department).ToList();
            return Ok(student);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id) {
            var student = context.Students.FirstOrDefault(s => s.Id == id);
            return Ok(student);
        }
        [HttpGet("name/ {Name}")]
        public IActionResult Get(string Name)
        {
            var student = context.Students.FirstOrDefault(s => s.Name == Name);
            return Ok(student);
        }
        [HttpPost]
        public IActionResult Post([FromBody] Student student)
        {
            context.Students.Add(student);
            context.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpPut]
        public IActionResult Put([FromRoute] int id, [FromBody] Student student)
        {
            Student oldstudent = context.Students.Include(e => e.Department).FirstOrDefault(s => s.Id == student.Id);
            if (ModelState.IsValid)
            {
                oldstudent.Name = student.Name;
                oldstudent.Address = student.Address;
                oldstudent.Department.Name = student.Department.Name;
                context.SaveChanges();
                return StatusCode(204);
            }
            return base.BadRequest(ModelState);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            var student = context.Students.FirstOrDefault(s => s.Id == id);
            context.Students.Remove(student);
            context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}/update-name")]
        public IActionResult UpdateStudentName(int id, [FromQuery] string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest();
            }

            var oldStudent = context.Students.FirstOrDefault(s => s.Id == id);
            if (oldStudent != null)
            {
            oldStudent.Name = name;
            context.SaveChanges();
            return NoContent();
            }
                return NotFound();


        }

    }
}
