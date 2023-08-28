using AutoMapper;
using CourseStore.Model.Courses.Entities;
using CourseWebApi.Model.Courses.Dtos;
using CourseWebApi.Model.Student.Dtos;

namespace CourseWebApi.Model.Tags.Profiles
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<Course, CourseModel>().ForMember(des => des.CourseId, opt => opt.MapFrom(src => src.Id));            
            CreateMap<CourseModel, Course>().ForMember(des => des.Id, opt => opt.MapFrom(src => src.CourseId));
            //Comment
            CreateMap<CourseComment, CommentModel>().ForMember(des => des.CommentId, opt => opt.MapFrom(src => src.Id));
            CreateMap<CommentModel, CourseComment>().ForMember(des => des.Id, opt => opt.MapFrom(src => src.CommentId));

        }
    }
}
