using CourseStore.Model.Courses.Entities;
using CourseStore.Model.Tags.Entities;
using CourseStore.Model.Teachers.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWebApi.Model.Courses.Dtos
{
    public class CourseQuery
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndTime { get; set; }
        public int Price { get; set; }
        public string ImageUrl { get; set; }
        public List<Tag> Tags { get; set; }
        public List<Teacher> Teachers { get; set; }
        public List<CourseComment> Comments { get; set; }
        public Byte[] RowVersion { get; set; }
    }
}
