using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Filtro.Models;
using Filtro.Services;

namespace Filtro.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentsService _studentService;

        public StudentsController(IStudentsService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public ActionResult <IEnumerable<Student>> GetAll()
        {
            try
            {
                return Ok(_studentService.GetStudents());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error for get students: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetOne(int id)
        {
            try
            {
                var student = _studentService.GetStudent(id);

                if (student == null)
                {
                    return NotFound($"Student with id {id} hasn't been found");
                }
                return Ok(student);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error for get student with id {id}: {ex.Message}");
            }
        }

        [HttpGet("{date}/birthday")]
        public ActionResult <IEnumerable<Student>> GetBirthday(DateOnly date)
        {
            try
            {
                var students = _studentService.GetStudentDate(date);

                if (students == null)
                {
                    return NotFound($"Student with birthday {date} hasn't been found");
                }
                return Ok(students);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error for get student with birthday {date}: {ex.Message}");
            }
        }
    }
}