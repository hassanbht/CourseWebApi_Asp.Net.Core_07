using AutoMapper;
using CourseWebApi.Model.Student.Dtos;
using CourseWebApi.Model.Student.Entities;

namespace CourseWebApi.Model.Student.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Entities.Student, StudentModel>().ForMember(des => des.StudentId, opt => opt.MapFrom(src => src.Id));
            CreateMap<StudentModel, Entities.Student>().ForMember(des => des.Id, opt => opt.MapFrom(src => src.StudentId));

            //PhoneNumber
            CreateMap<PhoneNumberModel, PhoneNumber>().ForMember(des => des.Number, opt => opt.MapFrom(src => src.Number));
            CreateMap<PhoneNumber, PhoneNumberModel>().ForMember(des => des.Number, opt => opt.MapFrom(src => src.Number));
        }
    }
}
