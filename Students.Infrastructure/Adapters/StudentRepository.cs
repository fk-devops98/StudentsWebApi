using Students.Domain.Entities;
using Students.Domain.Ports;
using Students.Infrastructure.Adapters.Base;
using Students.Infrastructure.Context;

namespace Students.Infrastructure.Adapters
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(PersistenceContext context)
            : base(context)
        {
        }

        public async Task<Student> UpdateStudent(Student student)
            => await UpdateAsync(student);

        public async Task<Student> CreateStudent(Student student)
            => await AddAsync(student);

        public async Task<Student> GetStudentById(int id)
            => await GetByIdAsync(id);

        public async Task<Student> GetStudentByUsername(string username)
            => (await GetAsync(s => s.Username == username)).FirstOrDefault();

        public async Task DeleteStudent(Student student)
            => await DeleteAsync(student);
    }
}