using CourseStore.BLL.Tags.Commands;
using CourseStore.DAL.Contexts;
using CourseStore.DAL.Framework;
using CourseWebApi.Core.Infra;
using CourseWebApi.DAL.Caching;
using CourseWebApi.Model.Tags.Profiles;
using CourseWebApi.WebAPI.Middleware;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CourseWebApi.WebAPI
{
    public static class HostingExtensions
    {
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            // Add services to the container.
            #region Data
            // Get Connection String from appsetting
            string? cnnString = builder.Configuration.GetConnectionString("SqlDataBaseConnection");
            builder.Services.AddDbContext<CourseStoreDbContext>(c => c.UseSqlServer(cnnString!).
                AddInterceptors(new AddAuditFieldInterceptor()));
            #endregion

            #region CQRS
            builder.Services.AddMediatR(typeof(CreateCoursesHandler).Assembly);
            #endregion

            #region cache
            //builder.Services.AddMemoryCache();
            builder.Services.AddSingleton<IRedisCacheService, RedisCacheService>();

            builder.Services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = builder.Configuration.GetConnectionString("RedisDatabase");
            });
            #endregion

            #region validators

            #endregion

            #region messaging

            #endregion

            #region elasticsearch

            #endregion

            builder.Services.AddControllers();

            #region Swagger
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAutoMapper(typeof(TagProfile).Assembly);
            #endregion
            return builder.Build();
        }

        public static WebApplication ConfigurePipeline(this WebApplication app)
        {

            #region Middleware
            app.UseMiddleware<ExceptionMiddleware>();
            #endregion
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
