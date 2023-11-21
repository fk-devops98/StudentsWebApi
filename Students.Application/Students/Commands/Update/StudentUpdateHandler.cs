using AutoMapper;
using MediatR;
using Students.Application.Students.Dto;
using Students.Domain.Entities;
using Students.Domain.Services;

namespace Students.Application.Students.Commands.Update
{
    public class StudentUpdateHandler : IRequestHandler<StudentUpdateCommand, StudentDto>
    {
        private readonly StudentsService _service;
        private readonly IMapper _mapper;

        public StudentUpdateHandler(StudentsService service, IMapper mapper)
            => (_service, _mapper) = (service, mapper);

        public async Task<StudentDto> Handle(StudentUpdateCommand request, CancellationToken cancellationToken)
        {
            var entityRequest = _mapper.Map<Student>(request);

            var entityUpdated = await _service.UpdateStudent(entityRequest);

            return _mapper.Map<StudentDto>(entityUpdated);
        }
    }
}