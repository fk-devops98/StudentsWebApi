using Students.Domain.Entities.Base;

namespace Students.Domain.Entities
{
    public class Student : BaseEntity<long>
    {
        public string Username { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public long Age { get; set; }
        public string Career { get; set; } = null!;
    }
}