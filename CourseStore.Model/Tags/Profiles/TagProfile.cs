using AutoMapper;
using CourseStore.Model.Tags.Commands;
using CourseStore.Model.Tags.Entities;
using CourseStore.Model.Tags.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWebApi.Model.Tags.Profiles
{
    public class TagProfile: Profile
    {
        public TagProfile()
        {            
            CreateMap<Tag, UpdateTag>().ForMember(des => des.TagId, opt => opt.MapFrom(src => src.Id));
            CreateMap<Tag, DeleteTag>().ForMember(des => des.TagId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
