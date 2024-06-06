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
    public class EnrollmentsChangeController : ControllerBase
    {
        private readonly IEnrollmentsService _enrollmentsService;

        public EnrollmentsChangeController(IEnrollmentsService enrollmentsService)
        {
            _enrollmentsService = enrollmentsService;
        }

        [HttpPut("{id}")]
        public IActionResult Change(int id)
        {
            _enrollmentsService.ChangeEnrollment(id);
            return Ok("Enrollment has changed the Status to Inactive successfully");
        }
    }
}