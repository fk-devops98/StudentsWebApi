using MediatR;
using Microsoft.AspNetCore.Mvc;
using Students.Application.Students.Commands.Create;
using Students.Application.Students.Commands.Delete;
using Students.Application.Students.Commands.Update;
using Students.Application.Students.Dto;
using Students.Application.Students.Queries.All;
using Students.Application.Students.Queries.ById;

namespace Students.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator _mediator = default!;

        public StudentsController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        public async Task<StudentDto> Post(StudentCreateCommand command) => await _mediator.Send(command);

        [HttpGet]
        public async Task<List<StudentDto>> Get() => await _mediator.Send(new StudentsQuery());

        [HttpGet("{id}")]
        public async Task<StudentDto> Get(int id) => await _mediator.Send(new StudentByIdQuery(id));

        [HttpPut("{id}")]
        public async Task<StudentDto> Put(StudentCreateCommand command, int id)
        {
            var studentUpdateRequest = new StudentUpdateCommand
            (id, command.Username, command.FirstName, command.LastName, command.Age, command.Career);

            return await _mediator.Send(studentUpdateRequest);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id) => await _mediator.Send(new StudentDeleteCommand(id));
    }
}