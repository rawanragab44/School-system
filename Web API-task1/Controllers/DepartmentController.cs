using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_API_task1.DTO;
using Web_API_task1.Models;

namespace Web_API_task1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        ITIentity context = new ITIentity();

        //get all
        [HttpGet]
        public IActionResult Get()
        {
            List<Department> department = context.Departments.ToList();
            return Ok(department);
        }

        //get by id
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var department = context.Departments.FirstOrDefault(d => d.Id == id);
            return Ok(department);
        }

        //get by name
        [HttpGet("name/ {Name}")]
        public IActionResult Get(string Name)
        {
            var department = context.Departments.FirstOrDefault(d => d.Name == Name);
            return Ok(department);
        }
        [HttpPost]
        public IActionResult Post([FromBody] Department department)
        {
            if(ModelState.IsValid)
            {
                context.Departments.Add(department);
                context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created);
            }
            return BadRequest(ModelState);
           
        }

        //update
        [HttpPut]
        public IActionResult Put([FromRoute] int id, [FromBody] Department department)
        {
            Department olddepartment = context.Departments.FirstOrDefault(d => d.Id == department.Id);
            if (ModelState.IsValid)
            {
                olddepartment.Name = department.Name;
                olddepartment.location = department.location;
                olddepartment.managerName = department.managerName;
                context.SaveChanges();
                return StatusCode(204);
            }
            return base.BadRequest(ModelState);
        }

        //delete
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var department = context.Departments.FirstOrDefault(d => d.Id == id);
            context.Departments.Remove(department);
            context.SaveChanges();
            return Ok();
        }

        [HttpGet("DTO/{id}")]
        public IActionResult GetDeptWithStudentNames(int id)
            {
            var dept = context.Departments.Include(e => e.Students).FirstOrDefault(d => d.Id == id);
            var deptWithStudentNames = new DeptWithStudentNames
            {
                Dept = dept.Id,
                DeptName = dept.Name,
                ManagerName = dept.managerName,
                StudentNames = new List<string>()
            };

            foreach (var student in dept.Students)
            {
                deptWithStudentNames.StudentNames.Add(student.Name);
            }
            return Ok(deptWithStudentNames);
        }
    }
}
