using AutoMapper;
using CourseWebApi.Model.Tags.Commands;
using CourseWebApi.Model.Repositories;
using CourseWebApi.Model.Tags.Profiles;
using CourseWebApi.Model.Tags.Validations;
using CourseWebApi.Test.Framework;
using CourseWebApi.Test.Tag.MockData;
using FluentValidation;
using FluentValidation.TestHelper;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using Ent = CourseWebApi.Model.Tags.Entities;

namespace CourseWebApi.Test.Tag
{
    public class UpdateTagTest : BaseTest<TagProfile>
    {      
       
        #region THEORY
        [Theory]
        [InlineData(-1, 103)]
        [InlineData(0, 103)]
        public void Should_have_error_when_less_zero(int Id, int ErrorCode)
        {
            var validator = new InlineUpdateTagValidator(v => v.RuleFor(x => x.TagId)
               .GreaterThan(1)
               .WithErrorCode("103")
               .WithMessage("The minimum Id is 1"));

            var result = validator.Validate(new UpdateTag { TagId = Id });
            bool hasError = result.Errors.Any(a => a.ErrorCode.Equals(ErrorCode.ToString()));
            Assert.True(hasError);
        }
        [Theory]
        [InlineData(2147483640, 104)]
        public void Should_succeed_when_Greater_max_int(int Id, int ErrorCode)
        {

            var validator = new InlineUpdateTagValidator(v => v.RuleFor(x => x.TagId)
               .GreaterThan(2147483647)
               .WithErrorCode("104")
               .WithMessage("The maximum Id is 2147483647"));

            var result = validator.Validate(new UpdateTag { TagId = Id });
            bool hasError = result.Errors.Any(a => a.ErrorCode.Equals(ErrorCode.ToString()));
            Assert.True(hasError);
        }

        [Theory]
        [InlineData(null, 100)]
        [InlineData("", 100)]
        public void Should_have_error_when_Name_is_null_or_empty(string Name, int ErrorCode)
        {
            var tag = new UpdateTag
            {
                TagName = Name,
            };
            CheckError(new UpdateTagValidator(), ErrorCode, tag);
        }

        [Theory]
        [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYsZsssaSASAggfhfhDSAASFDSASASAsa", 101)]
        [InlineData("A", 102)]
        public void Should_have_error_when_Name_is_max_min_length(string Name, int ErrorCode)
        {
            var tag = new UpdateTag
            {
                TagName = Name,
            };
            CheckError(new UpdateTagValidator(), ErrorCode, tag);
        }

        #endregion

        #region FACT
        [Fact]
        public void Should_not_have_error_when_tagname_is_specified()
        {
            var tag = new UpdateTag
            {
                TagName = "fluentvalidation",
            };
            var result = new UpdateTagValidator().TestValidate(tag);
            result.ShouldNotHaveValidationErrorFor(t => t.TagName);
        }
        [Fact]
        public async void Should_UpdateTag_when_NoValidation()
        {
            // Arrange
            var tag = new UpdateTag(3,"aspnetcore_environment");

            // Act
            var tagEntity = _mapper?.Map<Model.Tags.Entities.Tag>(tag);

            // ASSERT 
            Assert.NotNull(tagEntity);

            // Arrange
            await new DAL.Repositories.RepositoryDbContext<Model.Tags.Entities.Tag>(ctx).AddRangeAsync(MockDataHelper.GetFakeTagList(),new CancellationToken());
            tagEntity.TagName = "Edited";
            // Act
            bool result = await new DAL.Repositories.RepositoryDbContext<Model.Tags.Entities.Tag>(ctx).Update(tagEntity);

            // ASSERT 
            Assert.True(result);
        }

        [Fact]
        public async Task Should_UpdateTag_when_Validation()
        {
            // Arrange
            var tag = new UpdateTag(2,"aspnetcore");

            // Act
            var val = new UpdateTagValidator().Validate(tag);

            // ASSERT 
            Assert.True(val.IsValid);

            if (val.IsValid)
            {
                // Act
                var tagEntity = _mapper?.Map<Model.Tags.Entities.Tag>(tag);

                // ASSERT 
                Assert.NotNull(tagEntity);

                // Arrange               
                await new DAL.Repositories.RepositoryDbContext<Model.Tags.Entities.Tag>(ctx).AddRangeAsync(MockDataHelper.GetFakeTagList(), new CancellationToken());
                tagEntity.TagName = "Edited";
                // Act
                bool result = await new DAL.Repositories.RepositoryDbContext<Model.Tags.Entities.Tag>(ctx).Update(tagEntity);

                // ASSERT 
                Assert.True(result);
            }
        }
        #endregion

    }
}
