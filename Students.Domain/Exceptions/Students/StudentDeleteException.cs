using Students.Domain.Exceptions.Base;

namespace Students.Domain.Exceptions.Students
{
    public class StudentDeleteException : BaseException
    {
        public StudentDeleteException(string message) : base(message)
        {
        }
    }
}