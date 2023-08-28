using AutoMapper;
using CourseStore.Model.Teachers.Entities;
using CourseWebApi.Model.Teachers.Dtos;

namespace CourseWebApi.Model.Tags.Profiles
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
