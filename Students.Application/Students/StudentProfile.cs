using AutoMapper;
using Students.Application.Students.Commands.Create;
using Students.Application.Students.Commands.Update;
using Students.Application.Students.Dto;
using Students.Domain.Entities;

namespace Students.Application.Students
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentCreateCommand>().ReverseMap();
            CreateMap<Student, StudentUpdateCommand>().ReverseMap();
            CreateMap<Student, StudentDto>().ReverseMap();
        }
    }
}