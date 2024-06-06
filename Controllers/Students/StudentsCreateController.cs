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
    public class StudentsCreateController : ControllerBase
    {
        private readonly IStudentsService _studentService;

        public StudentsCreateController(IStudentsService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Student student)
        {
            try
            {
                if (student == null)
                {
                    return BadRequest("Data is null");
                }

                _studentService.AddStudent(student);
                return Ok(student);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error for create student: {ex.Message}");
            }
        }
    }
}