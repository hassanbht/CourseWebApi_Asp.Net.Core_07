using AutoMapper;
using CourseWebApi.DAL.DbContexts;
using CourseWebApi.Model.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace CourseWebApi.Test.Framework
{
    public class BaseTest<T> where T : Profile, new()
    {
        protected readonly CourseStoreDbContext ctx;
        protected IMapper _mapper;
        public BaseTest(CourseStoreDbContext? ctx = null, IMapper? mapper = null)
        {
            this.ctx = ctx ?? GetInMemoryDBContext();
            _mapper = mapper ?? CreateMapper();
        }
        protected CourseStoreDbContext GetInMemoryDBContext()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();
            var builder = new DbContextOptionsBuilder<CourseStoreDbContext>();
            var options = builder.UseInMemoryDatabase("CourseDB").UseInternalServiceProvider(serviceProvider).Options;
            CourseStoreDbContext dbContext = new CourseStoreDbContext(options);
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
            return dbContext;
        }

        protected IMapper CreateMapper()
        {
            //auto mapper configuration
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new T());
            });
            _mapper = mockMapper.CreateMapper();
            return _mapper;
        }
        protected void CheckError<TV>(AbstractValidator<TV> validator, int ErrorCode, TV vm)
        {
            var val = validator.Validate(vm);
            Assert.False(val.IsValid);

            if (!val.IsValid)
            {
                bool hasError = val.Errors.Any(a => a.ErrorCode.Equals(ErrorCode.ToString()));
                Assert.True(hasError);
            }
        }
               
    }

}
