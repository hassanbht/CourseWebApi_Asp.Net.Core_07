using CourseStore.DAL.Contexts;
using CourseStore.DAL.Framework;
using CourseWebApi.BLL.Students;
using CourseWebApi.DAL.DbContexts;
using CourseWebApi.DAL.Repositories;
using CourseWebApi.GrpcService.Infrastructures;
using CourseWebApi.GrpcService.Interceptors;
using CourseWebApi.GrpcService.Services.V1;
using CourseWebApi.Model.Repositories;
using CourseWebApi.Model.Services;
using CourseWebApi.Model.Tags.Profiles;
using Microsoft.EntityFrameworkCore;

namespace ourseWebApi.GrpcService
{
    public static class HostingExtensions
    {
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            ConfigurationManager configuration = builder.Configuration;
            // Add services to the container.
            #region Data
            builder.Services.AddDbContext<CourseStoreDbContext>(c => c.UseSqlServer(configuration.GetConnectionString("SqlDataBaseConnection")!).
                AddInterceptors(new AddAuditFieldInterceptor()));
            //builder.Services.AddDbContext<AuthDbContext>(c => c.UseSqlServer(configuration.GetConnectionString("JWTConnection")!));
            builder.Services.AddTransient(typeof(IRepository<>), typeof(RepositoryDbContext<>));
            builder.Services.AddScoped<IStudentService, StudentService>();
            #endregion
            #region Grpc Options

            builder.Services.AddGrpc(options =>
            {
                options.EnableDetailedErrors = true;
                options.ResponseCompressionLevel = System.IO.Compression.CompressionLevel.Fastest;
                options.Interceptors.Add<ExceptionInterceptor>();
            });

            builder.Services.AddGrpcReflection();
            #endregion

            #region AutoMapper
            builder.Services.AddAutoMapper(typeof(TagProfile).Assembly);
            #endregion
            return builder.Build();
        }

        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            app.MapGrpcReflectionService();
            app.MapGrpcService<StudentGrpcService>();

            // Minimal APIs
            //app.MapGet("/protos", (ProtoFileProvider protoFileProvider) =>
            //{
            //    return Results.Ok(protoFileProvider.GetAll());
            //});
            //app.MapGet("/protos/v{version:int}/{protoName}", (ProtoFileProvider protoFileProvider, int version, string protoName) =>
            //{
            //    string filePath = protoFileProvider.GetPath(version, protoName);
            //    if (string.IsNullOrEmpty(filePath))
            //        return Results.NotFound();
            //    return Results.File(filePath);
            //});
            //app.MapGet("/protos/v{version:int}/{protoName}/view", async (ProtoFileProvider protoFileProvider, int version, string protoName) =>
            //{
            //    string fileContent = await protoFileProvider.GetContent(version, protoName);
            //    if (string.IsNullOrEmpty(fileContent))
            //        return Results.NotFound();
            //    return Results.Text(fileContent);
            //});

            app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

            return app;
        }
    }

}
