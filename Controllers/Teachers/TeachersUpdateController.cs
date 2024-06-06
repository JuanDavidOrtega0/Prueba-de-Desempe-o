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
    public class TeachersUpdateController : ControllerBase
    {
        private readonly ITeachersService _teacherService;

        public TeachersUpdateController(ITeachersService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Teacher teacher)
        {
            try
            {
                if (teacher == null || id != teacher.Id)
                {
                    return BadRequest($"Data is null or teacher with id {id} doesn't exist");
                }

                _teacherService.UpdateTeacher(teacher);
                return Ok($"Teacher with id {id} has been updated successfully");
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Failed to update teacher with id {id}: {e.Message}");
            }
        }
    }
}