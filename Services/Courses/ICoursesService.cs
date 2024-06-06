using Filtro.Models;

namespace Filtro.Services
{
    public interface ICoursesService
    {
        IEnumerable<Course> GetCourses();

        IEnumerable<Course> GetCoursesTeacherId(int TeacherId);

        Course GetCourse(int id);

        void AddCourse(Course course);

        void UpdateCourse(Course course);
    }
}