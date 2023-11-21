using MediatR;
using Students.Application.Students.Dto;

namespace Students.Application.Students.Queries.All
{
    public record StudentsQuery: IRequest<List<StudentDto>>;
}