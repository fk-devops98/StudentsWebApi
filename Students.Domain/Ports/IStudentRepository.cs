using Students.Domain.Entities;
using Students.Domain.Ports.Base;

namespace Students.Domain.Ports
{
    public interface IStudentRepository : IBaseRepository<Student>
    {
        public Task<Student> CreateStudent(Student student);
        public Task<Student> UpdateStudent(Student student);
        public Task<Student> GetStudentById(int id);
        public Task<Student> GetStudentByUsername(string username);
        public Task DeleteStudent(Student student);
    }
}
