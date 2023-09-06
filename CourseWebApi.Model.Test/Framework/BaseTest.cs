using CourseStore.DAL.Contexts;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CourseWebApi.Test.Framework
{
    public class BaseTest
    {
        protected CourseStoreDbContext ctx;
        public BaseTest(CourseStoreDbContext ctx = null)
        {
            this.ctx = ctx ?? GetInMemoryDBContext();
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

        protected void CheckError<T>(AbstractValidator<T> validator, int ErrorCode, T vm)
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
