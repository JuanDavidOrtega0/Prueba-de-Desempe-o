using Filtro.Models;

namespace Filtro.Services
{
    public interface ITeachersService
    {
        IEnumerable<Teacher> GetTeachers();

        Teacher GetTeacher(int id);

        void AddTeacher(Teacher teacher);

        void UpdateTeacher(Teacher teacher);
    }
}