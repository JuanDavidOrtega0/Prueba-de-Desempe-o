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
    public class EnrollmentsCreateController : ControllerBase
    {
        private readonly IEnrollmentsService _enrollmentsService;

        public EnrollmentsCreateController(IEnrollmentsService enrollmentsService)
        {
            _enrollmentsService = enrollmentsService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Enrollment enrollment)
        {
            try
            {
                if (enrollment == null)
                {
                    return BadRequest("Data is null");
                }

                _enrollmentsService.AddEnrollment(enrollment);
                return Ok(enrollment);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error for create enrollment: {ex.Message}");
            }
        }
    }
}