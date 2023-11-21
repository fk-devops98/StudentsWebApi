using Students.Domain.Exceptions.Base;

namespace Students.Domain.Exceptions.Students
{
    public class StudentCreateException : BaseException
    {
        public StudentCreateException(string message) : base(message)
        {
        }
    }
}