using Dapper;
using MediatR;
using Students.Application.Students.Dto;
using System.Data;

namespace Students.Application.Students.Queries.All
{
    public class StudentsQueryHandler : IRequestHandler<StudentsQuery, List<StudentDto>>
    {
        private readonly IDbConnection _dapperSource;

        public StudentsQueryHandler(IDbConnection dapperSource)
            => _dapperSource = dapperSource;

        public async Task<List<StudentDto>> Handle(StudentsQuery request, CancellationToken cancellationToken)
        {
            var query = @"SELECT  Id, Username, FirstName, LastName, Age, Career FROM Student";

            var students = await _dapperSource.QueryAsync<StudentDto>(query);

            return students.ToList();
        }
    }
}