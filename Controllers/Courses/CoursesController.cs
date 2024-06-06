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
    public class CoursesController : ControllerBase
    {
        private readonly ICoursesService _courseService;

        public CoursesController(ICoursesService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public ActionResult <IEnumerable<Course>> GetAll()
        {
            try
            {
                return Ok(_courseService.GetCourses());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error for get courses: {ex.Message}");
            }
        }

        [HttpGet("{teacherId}/courses")]
        public ActionResult <IEnumerable<Course>> GetByTeacher(int teacherId)
        {
            try
            {
                var courses = _courseService.GetCoursesTeacherId(teacherId);

                if (courses == null)
                {
                    return NotFound($"Teacher with id {teacherId} hasn't been found");
                }
                return Ok(courses);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error for get courses by teacher with id {teacherId}: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetOne(int id)
        {
            try
            {
                var course = _courseService.GetCourse(id);

                if (course == null)
                {
                    return NotFound($"Course with id {id} hasn't been found");
                }
                return Ok(course);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error for get course with id {id}: {ex.Message}");
            }
        }
    }
}