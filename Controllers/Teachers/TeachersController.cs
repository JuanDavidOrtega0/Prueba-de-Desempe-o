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
    public class TeachersController : ControllerBase
    {
        private readonly ITeachersService _teacherService;

        public TeachersController(ITeachersService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpGet]
        public ActionResult <IEnumerable<Teacher>> GetAll()
        {
            try
            {
                return Ok(_teacherService.GetTeachers());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error for get teachers: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetOne(int id)
        {
            try
            {
                var teacher = _teacherService.GetTeacher(id);

                if (teacher == null)
                {
                    return NotFound($"Teacher with id {id} hasn't been found");
                }
                return Ok(teacher);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error for get teacher with id {id}: {ex.Message}");
            }
        }
    }
}