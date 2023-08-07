using CourseStore.BLL.Tags.Commands;
using CourseStore.DAL.Contexts;
using CourseStore.DAL.Framework;
using CourseWebApi.Model.Tags.Profiles;
using CourseWebApi.WebAPI.Middleware;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CourseWebApi.WebAPI
{
    public static  class HostingExtensions
    {      
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            // Add services to the container.
            // Get Connection String from appsetting
            var cnnString = builder.Configuration.GetConnectionString("StoreCnn");
            builder.Services.AddDbContext<CourseStoreDbContext>(c => c.UseSqlServer(cnnString).
                AddInterceptors(new AddAuditFieldInterceptor()));

            builder.Services.AddMediatR(typeof(CreateCoursesHandler).Assembly);

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAutoMapper(typeof(TagProfile).Assembly);

            return builder.Build();
        }

        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            app.UseMiddleware<ExceptionMiddleware>();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();
            return app;
        }
    }
}
