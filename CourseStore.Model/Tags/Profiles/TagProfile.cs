using AutoMapper;
using CourseWebApi.Model.Tags.Commands;
using CourseWebApi.Model.Tags.Entities;

namespace CourseWebApi.Model.Tags.Profiles
{
    public class TagProfile : Profile
    {
        public TagProfile()
        {
            CreateMap<Tag, CreateTag>().ForMember(des => des.TagName, opt => opt.MapFrom(src => src.TagName));
            CreateMap<CreateTag, Tag>().ForMember(des => des.TagName, opt => opt.MapFrom(src => src.TagName));

            CreateMap<Tag, UpdateTag>().ForMember(des => des.TagId, opt => opt.MapFrom(src => src.Id));
            CreateMap<UpdateTag,Tag>().ForMember(des => des.Id, opt => opt.MapFrom(src => src.TagId));

            CreateMap<Tag, DeleteTag>().ForMember(des => des.TagId, opt => opt.MapFrom(src => src.Id));
            CreateMap<DeleteTag,Tag>().ForMember(des => des.Id, opt => opt.MapFrom(src => src.TagId));
        }
    }
}
