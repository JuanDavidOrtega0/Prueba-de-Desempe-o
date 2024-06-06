using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Filtro.Models;
using Filtro.Services;
using Microsoft.AspNetCore.Mvc;

namespace Filtro.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesUpdateController : ControllerBase
    {
        private readonly ICoursesService _courseService;

        public CoursesUpdateController(ICoursesService courseService)
        {
            _courseService = courseService;
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Course course)
        {
            try
            {
                if (course == null || id != course.Id)
                {
                    return BadRequest($"Data is null or course with id {id} doesn't exist");
                }

                _courseService.UpdateCourse(course);
                return Ok($"Course with id {id} has been updated successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to update course with id {id}: {ex.Message}");
            }
        }
    }
}