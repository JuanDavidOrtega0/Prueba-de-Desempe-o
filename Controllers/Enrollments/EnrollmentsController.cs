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
    public class EnrollmentsController : ControllerBase
    {
        private readonly IEnrollmentsService _enrollmentsService;

        public EnrollmentsController(IEnrollmentsService enrollmentsService)
        {
            _enrollmentsService = enrollmentsService;
        }

        [HttpGet]
        public ActionResult <IEnumerable<Enrollment>> GetAll()
        {
            try
            {
                return Ok(_enrollmentsService.GetEnrollments());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error for get enrollment: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetOne(int id)
        {
            try
            {
                var enrollment = _enrollmentsService.GetEnrollment(id);

                if (enrollment == null)
                {
                    return NotFound($"Enrollment with id {id} hasn't been found");
                }
                return Ok(enrollment);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error for get enrollment with id {id}: {ex.Message}");
            }
        }

        [HttpGet("{date}/date")]
        public ActionResult <IEnumerable<Enrollment>> GetDate(DateOnly date)
        {
            try
            {
                var enrollment = _enrollmentsService.GetEnrollmentDate(date);

                if (enrollment == null)
                {
                    return NotFound($"Enrollment with date {date} hasn't been found");
                }
                return Ok(enrollment);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error for get enrollment with date {date}: {ex.Message}");
            }
        }

        [HttpGet("{studentId}/students")]
        public ActionResult <IEnumerable<Enrollment>> GetEnrollmentsStudent(int studentId)
        {
            try
            {
                var enrollment = _enrollmentsService.GetEnrollmentsStudentId(studentId);

                if (enrollment == null)
                {
                    return NotFound($"Enrollment with student id {studentId} hasn't been found");
                }
                return Ok(enrollment);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error for get enrollment with student id {studentId}: {ex.Message}");
            }
        }
    }
}