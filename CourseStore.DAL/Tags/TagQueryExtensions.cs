using CourseWebApi.Model.Tags.Dtos;
using CourseWebApi.Model.Tags.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourseWebApi.DAL.Tags;

public static class TagQueryExtensions
{
    public static IQueryable<Tag> WhereOver(this IQueryable<Tag> tags, string tagName)
    {
        if (!string.IsNullOrEmpty(tagName))
            tags = tags.Where(t => t.TagName.Contains(tagName));
        return tags;
    }
    public static List<TagQuery> ToTagQr(this IQueryable<Tag> tags)
    {
        return tags.Select(c => new TagQuery(c.Id, c.TagName)).ToList();
    }

    public static async Task<List<TagQuery>> ToTagQrAsync(this IQueryable<Tag> tags)
    {
        return await tags.Select(c => new TagQuery(c.Id, c.TagName)).ToListAsync();
    }
}