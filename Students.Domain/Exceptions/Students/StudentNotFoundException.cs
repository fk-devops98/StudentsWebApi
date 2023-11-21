using Students.Domain.Exceptions.Base;

namespace Students.Domain.Exceptions.Students
{
    public class StudentNotFoundException : BaseException
    {
        public StudentNotFoundException(string message) : base(message)
        {
        }
    }
}