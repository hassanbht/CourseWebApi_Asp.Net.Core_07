using CourseStore.BLL.Tags.Commands;
using CourseStore.DAL.Contexts;
using CourseStore.DAL.Framework;
using CourseWebApi.Core.Infra;
using CourseWebApi.DAL.Caching;
using CourseWebApi.Model.Framework;
using CourseWebApi.Model.Tags.Profiles;
using CourseWebApi.WebAPI.Middleware;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Text;
using System.Text.Json.Serialization;

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

            #region UserSecrets
            builder.Configuration.AddUserSecrets("427c907a-7762-476b-a42f-c0b7b597120e");
            #endregion

            #region JsonOptions
            builder.Services.Configure<JsonOptions>(c =>
            {
                c.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            });
            #endregion
            #region JwtOptions
            JwtOptions jwtOptions = new JwtOptions();
            builder.Configuration.GetSection("JwtOptions").Bind(jwtOptions);
            builder.Services.AddSingleton<JwtOptions>(jwtOptions);

            //Configuring the Authentication Service
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opts =>
                {
                    //convert the string signing key to byte array
                    byte[] signingKeyBytes = Encoding.UTF8
                        .GetBytes(jwtOptions.SigningKey);

                    opts.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtOptions.Issuer,
                        ValidAudience = jwtOptions.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(signingKeyBytes)
                    };
                });

            // Configuring the Authorization Service
            builder.Services.AddAuthorization();
            #endregion


            #region Serilog
            builder.Host.UseSerilog((ctx, lc) => lc
               .MinimumLevel.Debug()
               .WriteTo.File(@"f:\log\log.txt", rollingInterval: RollingInterval.Day)
               .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level}] ({Application}/{MachineName}/{ThreadId}{NewLine}) {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}")
               .Enrich.FromLogContext()
               .ReadFrom.Configuration(ctx.Configuration));
            #endregion

            #region Seq log
            builder.Logging.AddSeq("http://localhost:5342/");
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
            builder.Services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo { Title = "RefreshTokenExample", Version = "v1" });
                opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                });
                opt.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });
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
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();
            return app;
        }
    }
}
