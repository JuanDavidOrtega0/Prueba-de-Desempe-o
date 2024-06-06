using Filtro.Models;

namespace Filtro.Services
{
    public interface IEnrollmentsService
    {
        IEnumerable<Enrollment> GetEnrollments();

        Enrollment GetEnrollment(int id);

        IEnumerable<Enrollment> GetEnrollmentDate(DateOnly date);

        IEnumerable<Enrollment> GetEnrollmentsStudentId(int studentId);

        void AddEnrollment(Enrollment enrollment);

        void UpdateEnrollment(Enrollment enrollment);

        void ChangeEnrollment(int id);
    }
}