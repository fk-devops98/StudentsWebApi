using MediatR;
using Students.Domain.Services;

namespace Students.Application.Students.Commands.Delete
{
    public class StudentDeleteHandler : IRequestHandler<StudentDeleteCommand>
    {
        private readonly StudentsService _service;

        public StudentDeleteHandler(StudentsService service) => _service = service;

        public async Task Handle(StudentDeleteCommand request, CancellationToken cancellationToken)
        {
            await _service.DeleteStudentById(request.Id);
        }
    }
}