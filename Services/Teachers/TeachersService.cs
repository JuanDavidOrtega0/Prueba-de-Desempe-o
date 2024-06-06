using Microsoft.EntityFrameworkCore;
using Filtro.Data;
using Filtro.Models;

namespace Filtro.Services
{
    public class TeachersService : ITeachersService
    {
        private readonly BaseContext _context;

        public TeachersService(BaseContext context)
        {
            _context = context;
        }

        public IEnumerable<Teacher> GetTeachers()
        {
            return _context.Teachers.ToList();
        }

        public Teacher GetTeacher(int id)
        {
            return _context.Teachers.Find(id);
        }

        public void AddTeacher(Teacher teacher)
        {
            _context.Teachers.Add(teacher);
            _context.SaveChanges();
        }

        public void UpdateTeacher(Teacher teacher)
        {
            _context.Teachers.Update(teacher);
            _context.SaveChanges();
        }
    }
}