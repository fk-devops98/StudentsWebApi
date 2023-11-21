using MediatR;
using Students.Application.Students.Dto;
using System.ComponentModel.DataAnnotations;

namespace Students.Application.Students.Commands.Update
{
    public record StudentUpdateCommand
    (
        long Id,
        [Required][MaxLength(20, ErrorMessage = $"The MaxLength to the Field [{nameof(Username)}], is 20.")]
        string Username,
        [Required][MaxLength(20, ErrorMessage = $"The MaxLength to the Field [{nameof(FirstName)}], is 20.")]
        string FirstName,
        [Required][MaxLength(20, ErrorMessage = $"The MaxLength to the Field [{nameof(LastName)}], is 20.")]
        string LastName,
        long Age,
        [Required][MaxLength(50, ErrorMessage = $"The MaxLength to the Field [{nameof(Career)}], is 50.")]
        string Career
    ) : IRequest<StudentDto>;
}