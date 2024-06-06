using Microsoft.EntityFrameworkCore;
using Filtro.Data;
using Filtro.Models;

namespace Filtro.Services
{
    public class StudentsService : IStudentsService
    {
        private readonly BaseContext _context;

        public StudentsService(BaseContext context)
        {
            _context = context;
        }

        public IEnumerable<Student> GetStudents()
        {
            return _context.Students.ToList();
        }

        public Student GetStudent(int id)
        {
            return _context.Students.Find(id);
        }

        public IEnumerable<Student> GetStudentDate(DateOnly date)
        {
            return _context.Students.Where(s => s.BirthDate == date).ToList();
        }

        public void AddStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public void UpdateStudent(Student student)
        {
            _context.Students.Update(student);
            _context.SaveChanges();
        }
    }
}