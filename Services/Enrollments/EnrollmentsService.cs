using Filtro.Data;
using Microsoft.EntityFrameworkCore;
using Filtro.Models;

namespace Filtro.Services
{
    public class EnrollmentsService : IEnrollmentsService
    {
        private readonly BaseContext _context;

        public EnrollmentsService(BaseContext context)
        {
            _context = context;
        }

        public IEnumerable<Enrollment> GetEnrollments()
        {
            var enrollments = _context.Enrollments.Include(e => e.Student).Include(e => e.Course).Include(e => e.Course.Teacher).ToList();
            return enrollments;
        }

        public Enrollment GetEnrollment(int id)
        {
            var enrollment = _context.Enrollments.Include(e => e.Student).Include(e => e.Course).Include(e => e.Course.Teacher).FirstOrDefault(e => e.Id == id);
            return enrollment;
        }

        public IEnumerable<Enrollment> GetEnrollmentDate(DateOnly date)
        {
            return _context.Enrollments.Where(e => e.Date == date && e.Status != "Inactive").Include(e => e.Student).Include(e => e.Course).Include(e => e.Course.Teacher).ToList();
        }

        public IEnumerable<Enrollment> GetEnrollmentsStudentId(int studentId)
        {
            return _context.Enrollments.Where(e => e.StudentId == studentId && e.Status != "Inactive").Include(e => e.Student).Include(e => e.Course).Include(e => e.Course.Teacher).ToList();
        }

        public void AddEnrollment(Enrollment enrollment)
        {
            _context.Enrollments.Add(enrollment);
            _context.SaveChanges();
        }

        public void UpdateEnrollment(Enrollment enrollment)
        {
            _context.Enrollments.Update(enrollment);
            _context.SaveChanges();
        }

        public void ChangeEnrollment(int id)
        {
            var enrollment = _context.Enrollments.FirstOrDefault(e => e.Id == id);

            if (enrollment != null)
            {
                enrollment.Status = "Inactive";
                _context.Update(enrollment);
                _context.SaveChanges();
            }
        }
    }
}