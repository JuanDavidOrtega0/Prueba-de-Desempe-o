using Filtro.Models;

namespace Filtro.Services
{
    public interface IStudentsService
    {
        IEnumerable<Student> GetStudents();

        Student GetStudent(int id);

        IEnumerable<Student> GetStudentDate(DateOnly date);

        void AddStudent(Student student);

        void UpdateStudent(Student student);
    }
}