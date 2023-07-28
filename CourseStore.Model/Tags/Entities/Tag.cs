﻿using CourseStore.Model.Courses.Entities;
using CourseStore.Model.Framework;

namespace CourseStore.Model.Tags.Entities;

public class Tag : BaseEntity
{
    public string TagName { get; set; }
    public ICollection<CourseTag> CourseTags { get; set; }
}
