using Dapper;
using MediatR;
using Students.Application.Students.Dto;
using Students.Domain.Exceptions.Students;
using System.Data;

namespace Students.Application.Students.Queries.ById
{
    public class StudentByIdQueryHandler : IRequestHandler<StudentByIdQuery, StudentDto>
    {
        private readonly IDbConnection _dapperSource;

        public StudentByIdQueryHandler(IDbConnection dapperSource)
            => _dapperSource = dapperSource;

        public async Task<StudentDto> Handle(StudentByIdQuery request, CancellationToken cancellationToken)
        {
            var query = @"SELECT  Id, Username, FirstName, LastName, Age, Career FROM Student WHERE Id = @Id";
            var student = await _dapperSource.QueryFirstOrDefaultAsync<StudentDto>(query, param: request) 
                ?? throw new StudentNotFoundException($"Student not exist by id: {request.Id}");

            return student;
        }
    }
}