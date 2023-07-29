using CourseStore.BLL.Framework;
using CourseStore.DAL.Contexts;
using CourseStore.Model.Courses.Entities;
using CourseStore.Model.Tags.Commands;
using CourseStore.Model.Tags.Entities;
using CourseWebApi.Model.Courses.Commands;
using System.Diagnostics;

namespace CourseWebApi.BLL.Courses.Commands;

public class CreateCoursesHandler : BaseApplicationServiceHandler<CreateCourse, Course>
{
    public CreateCoursesHandler(CourseStoreDbContext courseStoreDbContext) : base(courseStoreDbContext)
    {
    }

    protected override async Task HandleRequest(CreateCourse request, CancellationToken cancellationToken)
    {
        Course course = new()
        {
            Title = request.Title,
        ShortDescription = request.ShortDescription,
        Description = request.Description,
        StartDate = request.StartDate,
        EndTime = request.EndTime,
        Price = request.Price,
        ImageUrl = request.ImageUrl,
        CourseTags = request.CourseTags.ToList(),
        CourseTeachers = request.CourseTeachers,
        CourseComments = request.CourseComments
    };
        await _courseStoreDbContext.Courses.AddAsync(course);
        await _courseStoreDbContext.SaveChangesAsync();
        AddResult(course);
    }

    
}



