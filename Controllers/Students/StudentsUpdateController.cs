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
    public class StudentsUpdateController : ControllerBase
    {
        private readonly IStudentsService _studentService;

        public StudentsUpdateController(IStudentsService studentService)
        {
            _studentService = studentService;
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Student student)
        {
            try
            {
                if (student == null || id != student.Id)
                {
                    return BadRequest($"Data is null or student with id {id} doesn't exist");
                }

                _studentService.UpdateStudent(student);
                return Ok($"Student with id {id} has been updated successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to update student with id {id}: {ex.Message}");
            }
        }
    }
}