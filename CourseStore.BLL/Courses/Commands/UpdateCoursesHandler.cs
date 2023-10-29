
using Microsoft.EntityFrameworkCore;

namespace CourseWebApi.BLL.Courses.Commands;

//public class UpdateCoursesHandler : BaseApplicationServiceHandler<UpdateCourse, Course>
//{
//    public UpdateCoursesHandler(CourseStoreDbContext courseStoreDbContext) : base(courseStoreDbContext)
//    {
//    }
//    protected override async Task HandleRequest(UpdateCourse request, CancellationToken cancellationToken)
//    {
//        Course? courses = await _courseStoreDbContext.Courses.SingleOrDefaultAsync(c => c.Id == request.Id, cancellationToken: cancellationToken);
//        if (courses == null)
//        {
//            AddError($"تگ با شناسه {request.Id} یافت نشد");
//        }
//        else
//        {
//            courses.Title = request.Title;
//            await _courseStoreDbContext.SaveChangesAsync();
//            AddResult(courses);
//        }
//    }
//}



