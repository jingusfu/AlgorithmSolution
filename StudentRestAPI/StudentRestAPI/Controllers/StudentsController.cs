using Microsoft.AspNetCore.Mvc;
using StudentRestAPI.Models;
using StudentRestAPI.Repositories;

namespace StudentRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _repository;
        private readonly ILogger<StudentsController> _logger;
        public StudentsController(IStudentRepository repository, ILogger<StudentsController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        // GET: api/Students/5，get student by id
        [HttpGet("{id}")]
        public IActionResult GetStudent(long id)
        {
            _logger.LogInformation("Getting student with Id: {Id}", id);
            var student = FindStudent(id);
            return student == null ? NotFound() : Ok(student);
        }

        // GET: api/Students, get all students
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            _logger.LogInformation("Getting all students");
            var students = _repository.GetAllStudents();
            return Ok(students);
        }

        // PUT: api/Students/5, update student by id
        [HttpPut("{id}")]
        public IActionResult UpdateStudent(long id, [FromBody] Student student)
        {
            _logger.LogInformation("Updatting student with Id: {Id}", id);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingStudent = FindStudent(id);
            if (existingStudent == null)
                return NotFound();

            _repository.UpdateStudent(id, student);
            return NoContent();
        }

        // POST: api/Students, create a new student
        [HttpPost]
        public IActionResult CreateStudent([FromBody] Student student)
        {
            _logger.LogInformation("Creating a student");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _repository.InsertStudent(student);
            return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
        }

        // DELETE: api/Students/5, delete student by id
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(long id)
        {
            _logger.LogInformation("Deleting a student with Id: {Id}", id);
            var student = FindStudent(id);
            if (student == null)
                return NotFound();

            _repository.DeleteStudent(id);
            return NoContent();
        }

        //Just to show we can move common logic to a private method and it can be called multiple times elsewhere
        private Student FindStudent(long id)
        {
            var student = _repository.GetStudent(id);
            return student;
        }
    }
}
