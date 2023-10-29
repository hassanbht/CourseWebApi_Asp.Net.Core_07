using AutoMapper;
using CourseWebApi.Model.Teachers.Dtos;
using CourseWebApi.Model.Teachers.Entities;

namespace CourseWebApi.Model.Teachers.Profiles
{
    public class TeacherProfile : Profile
    {
        public TeacherProfile()
        {
            CreateMap<Teacher, TeacherModel>().ForMember(des => des.TeacherId, opt => opt.MapFrom(src => src.Id));
            CreateMap<TeacherModel, Teacher>().ForMember(des => des.Id, opt => opt.MapFrom(src => src.TeacherId));
        }
    }
}
