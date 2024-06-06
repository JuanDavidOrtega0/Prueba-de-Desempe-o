using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Filtro.Services;
using Filtro.Models;

namespace Filtro.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnrollmentsUpdateController : ControllerBase
    {
        private readonly IEnrollmentsService _enrollmentsService;

        public EnrollmentsUpdateController(IEnrollmentsService enrollmentsService)
        {
            _enrollmentsService = enrollmentsService;
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Enrollment enrollment)
        {
            try
            {
                if (enrollment == null || id != enrollment.Id)
                {
                    return BadRequest($"Data is null or enrollment with id {id} doesn't exist");
                }

                _enrollmentsService.UpdateEnrollment(enrollment);
                return Ok($"Enrollment with id {id} has been updated successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to update enrollment with id {id}: {ex.Message}");
            }
        }
    }
}