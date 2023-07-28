using CourseStore.Model.Courses.Entities;
using CourseStore.Model.Framework;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWebApi.Model.Courses.Commands
{
    public class CreateCourse: IRequest<ApiResult<Course>>
    {
        [Required, StringLength(100, MinimumLength = 2)]
        public string Title { get; set; }
        [Required, StringLength(500, MinimumLength = 2)]
        public string ShortDescription { get; set; }
        [Required, StringLength(5000,MinimumLength = 2)]
        public string Description { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        public DateTime EndTime { get; set; }
        [Required]
        public int Price { get; set; }
        [Required, StringLength(1000, MinimumLength = 2)]
        public string ImageUrl { get; set; }
        public ICollection<CourseTag> CourseTags { get; set; }
        public ICollection<CourseTeacher> CourseTeachers { get; set; }
        public ICollection<CourseComment> CourseComments { get; set; }
    }
}
