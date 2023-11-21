namespace Students.Application.Students.Dto
{
    public class StudentDto
    {
        public long Id { get; set; }
        public string Username { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public long Age { get; set; }
        public string Career { get; set; } = null!;
    }
}
