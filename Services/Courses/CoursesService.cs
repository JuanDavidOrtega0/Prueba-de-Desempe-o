using Filtro.Models;
using Filtro.Data;
using Microsoft.EntityFrameworkCore;

namespace Filtro.Services
{
    public class CoursesService : ICoursesService
    {
        private readonly BaseContext _context;

        public CoursesService(BaseContext context)
        {
            _context = context;
        }

        public IEnumerable<Course> GetCourses()
        {
            var courses = _context.Courses.Include(c => c.Teacher).ToList();
            return courses;
        }

        public IEnumerable<Course> GetCoursesTeacherId(int teacherId)
        {
            var courses = _context.Courses.Where(c => c.TeacherId == teacherId).Include(c => c.Teacher).ToList();
            return courses;
        }

        public Course GetCourse(int id)
        {
            var course = _context.Courses.Include(c => c.Teacher).FirstOrDefault(c => c.Id == id);
            return course;
        }

        public void AddCourse(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
        }

        public void UpdateCourse(Course course)
        {
            _context.Courses.Update(course);
            _context.SaveChanges();
        }
    }
}