using EFAndLinqPractice_SchoolAPI.Services;
using EFAndLinqPractice_SchoolAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EFAndLinqPractice_SchoolAPI.Controllers
{
    [ApiController]
    [Route("api/students/")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public IActionResult GetAllStudents()
        {
            var students = _studentService.GetAll();
            
            return Ok(students);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetStudent(int id)
        {
            var student = _studentService.GetById(id);
            
            return Ok(student);
        }
        
        [HttpGet("course/{courseId:int}")]
        public IActionResult GetStudentsByCourseId(int courseId)
        {
            var students = _studentService.GetStudentsByCourseId(courseId);
            
            return Ok(students);
        }

        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            var createdStudent = _studentService.Create(student);
            
            return CreatedAtAction(nameof(GetStudent), new { id = createdStudent.Id}, student);
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteStudent(int id)
        {
            if (id == 0)
                return BadRequest("Not a valid student id");
            
            _studentService.DeleteById(id);
            
            return Ok("Student has been removed successfully");
        }
    }
}