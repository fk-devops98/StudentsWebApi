using Students.Domain.Exceptions.Base;

namespace Students.Domain.Exceptions.Students
{
    public class StudentUpdateException : BaseException
    {
        public StudentUpdateException(string message) : base(message)
        {
        }
    }
}