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
    public class CoursesCreateController : ControllerBase
    {
        private readonly ICoursesService _coursesService;

        public CoursesCreateController(ICoursesService coursesService)
        {
            _coursesService = coursesService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Course course)
        {
            try
            {
                if (course == null)
                {
                    return BadRequest("Data is null");
                }

                _coursesService.AddCourse(course);
                return Ok(course);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error for create course: {ex.Message}");
            }
        }
    }
}