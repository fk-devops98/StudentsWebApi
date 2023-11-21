using AutoMapper;
using MediatR;
using Students.Application.Students.Dto;
using Students.Domain.Entities;
using Students.Domain.Services;

namespace Students.Application.Students.Commands.Create
{
    public class StudentCreateHandler : IRequestHandler<StudentCreateCommand, StudentDto>
    {
        private readonly StudentsService _service;
        private readonly IMapper _mapper;

        public StudentCreateHandler(StudentsService service, IMapper mapper)
            => (_service, _mapper) = (service, mapper);

        public async Task<StudentDto> Handle(StudentCreateCommand request, CancellationToken cancellationToken)
        {
            var entityRequest = _mapper.Map<Student>(request);

            var entityCreated = await _service.CreateStudent(entityRequest);

            return _mapper.Map<StudentDto>(entityCreated);
        }
    }
}