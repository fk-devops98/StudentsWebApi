using MediatR;

namespace Students.Application.Students.Commands.Delete
{
    public record StudentDeleteCommand
    (
        long Id
    ): IRequest;
}