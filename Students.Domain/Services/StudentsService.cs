using Students.Domain.Entities;
using Students.Domain.Exceptions.Students;
using Students.Domain.Ports;
using Students.Domain.Services.Base;

namespace Students.Domain.Services
{
    [DomainService]
    public class StudentsService
    {
        private readonly IStudentRepository _repository;

        public StudentsService(IStudentRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository), "Repository unavailable");
        }

        public async Task<Student> CreateStudent(Student student)
        {
            var existStudentByUsername = await _repository.GetStudentByUsername(student.Username);
            
            if (existStudentByUsername != null) throw new StudentCreateException($"Student exist by username: {student.Username}");
            
            return await _repository.CreateStudent(student);
        }

        public async Task<Student> UpdateStudent(Student student)
        {
            var existStudentById = await _repository.GetByIdAsync(student.Id) ?? throw new StudentUpdateException($"Student not exist by id: {student.Id}");

            existStudentById.Username = student.Username;
            existStudentById.FirstName = student.FirstName;
            existStudentById.LastName = student.LastName;
            existStudentById.Age = student.Age;
            existStudentById.Career = student.Career;
            
            return await _repository.UpdateStudent(existStudentById);
        }

        public async Task DeleteStudentById(long id)
        {
            Student studentExistById = await _repository.GetByIdAsync(id) ?? throw new StudentDeleteException($"Student not exist by id: {id}");
            
            await _repository.DeleteStudent(studentExistById);
        }
    }
}
