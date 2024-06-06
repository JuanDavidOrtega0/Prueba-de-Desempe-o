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
    public class TeachersCreateController : ControllerBase
    {
        private readonly ITeachersService _teachersService;

        public TeachersCreateController(ITeachersService teachersService)
        {
            _teachersService = teachersService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Teacher teacher)
        {
            try
            {
                if (teacher == null)
                {
                    return BadRequest("Data is null");
                }

                _teachersService.AddTeacher(teacher);
                return Ok(teacher);
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Error for create teacher: {e.Message}");
            }
        }
    }
}