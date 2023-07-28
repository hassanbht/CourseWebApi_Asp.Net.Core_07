using CourseStore.Model.Courses.Entities;
using CourseStore.Model.Tags.Dtos;
using CourseStore.Model.Tags.Entities;
using CourseWebApi.Model.Courses.Dtos;
using Microsoft.EntityFrameworkCore;

namespace CourseStore.DAL.Tags;

public static class CourseQueryExtensions
{
    public static IQueryable<Course> WhereOver(this IQueryable<Course> tags ,string title)
    {
        if (!string.IsNullOrEmpty(title))
            tags = tags.Where(t => t.Title.Contains(title));
        return tags;
    }
    public static List<CourseQuery> ToCourseQuery(this IQueryable<Course> courses)
    {
        return courses.Select(c => new CourseQuery
        {
            Id = c.Id,
            Title = c.Title,
            ShortDescription=c.ShortDescription,
            Description = c.Description,
            Price   = c.Price,
            StartDate=c.StartDate,
            EndTime=c.EndTime,
            ImageUrl=c.ImageUrl,

            CourseComments = c.CourseComments,

        }).ToList();
    }

    public static async Task<List<CourseQuery>> ToCourseQueryAsync(this IQueryable<Course> courses)
    {
        return await courses.Select(c => new CourseQuery
        {
            Id = c.Id,
            Title = c.Title,
        }).ToListAsync();
    }
}