using CourseStore.Model.Courses.Entities;
using CourseStore.Model.Tags.Entities;
using CourseStore.Model.Teachers.Entities;
using CourseWebApi.Model.Courses.Dtos;
using Microsoft.EntityFrameworkCore;

namespace CourseStore.DAL.Tags;

public static class CourseQueryExtensions
{
    public static IQueryable<Course> WhereOver(this IQueryable<Course> tags, string title)
    {
        if (!string.IsNullOrEmpty(title))
            tags = tags.Where(t => t.Title.Contains(title));
        return tags;
    }
    //public static List<CourseQuery> ToCourseQuery(this IQueryable<Course> courses)
    //{
    //    return courses.Select(c => new CourseQuery(
    //         c.Id,
    //        c.Title,
    //         c.ShortDescription,
    //         c.Description,
    //          c.StartDate,
    //         c.EndTime,
    //         c.Price,
    //         c.ImageUrl,
    //         (from tag in c.CourseTags
    //          from course in courses
    //          where tag.CourseId == course.Id
    //          select new Tag(tag.Tag.TagName)).ToList(),
    //         (from teacher in c.CourseTeachers
    //          from course in courses
    //          where teacher.CourseId == course.Id
    //          select new Teacher(
    //               teacher.Teacher.FirstName,
    //               teacher.Teacher.LastName,
    //               teacher.Teacher.FullName,
    //               teacher.Teacher.Address
    //          )).ToList(),
    //          c.CourseComments.ToList(),
    //          c.RowVersion
    //    )).ToList();
    //}

    //public static async Task<List<CourseQuery>> ToCourseQueryAsync(this IQueryable<Course> courses)
    //{
    //    return await courses.Select(c => new CourseQuery(
    //         c.Id,
    //        c.Title,
    //         c.ShortDescription,
    //         c.Description,
    //          c.StartDate,
    //         c.EndTime,
    //         c.Price,
    //         c.ImageUrl,
    //         (from tag in c.CourseTags
    //          from course in courses
    //          where tag.CourseId == course.Id
    //          select new Tag(tag.Tag.TagName)).ToList(),
    //         (from teacher in c.CourseTeachers
    //          from course in courses
    //          where teacher.CourseId == course.Id
    //          select new Teacher(
    //               teacher.Teacher.FirstName,
    //               teacher.Teacher.LastName,
    //               teacher.Teacher.FullName,
    //               teacher.Teacher.Address
    //          )).ToList(),
    //          c.CourseComments.ToList(),
    //          c.RowVersion
    //    )).ToListAsync();
    //}

}