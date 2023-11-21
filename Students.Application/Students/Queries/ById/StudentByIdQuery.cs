using MediatR;
using Students.Application.Students.Dto;

namespace Students.Application.Students.Queries.ById
{
    public record StudentByIdQuery
    (
        long Id
    ): IRequest<StudentDto>;
}