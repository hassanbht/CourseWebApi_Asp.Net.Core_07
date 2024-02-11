using CourseWebApi.Model.Tags.Commands;
using CourseWebApi.Model.Tags.Profiles;
using CourseWebApi.Model.Tags.Validations;
using CourseWebApi.Test.Framework;
using FluentValidation.TestHelper;
using Ent = CourseWebApi.Model.Tags.Entities;

namespace CourseWebApi.Test.Tag
{
    public class CreateTagTest : BaseTest<TagProfile>
    {
        #region THEORY
        [Theory]
        [InlineData(null, 100)]
        [InlineData("", 100)]
        public void Should_have_error_when_Name_is_null_or_empty(string Name, int ErrorCode)
        {
            var tag = new CreateTag
            {
                TagName = Name,
            };
            CheckError(new CreateTagValidator(), ErrorCode, tag);
        }

        [Theory]
        [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYsZsssaSASAggfhfhDSAASFDSASASAsa", 101)]
        [InlineData("A", 102)]
        public void Should_have_error_when_Name_is_max_min_length(string Name, int ErrorCode)
        {
            var tag = new CreateTag
            {
                TagName = Name,
            };
            CheckError(new CreateTagValidator(), ErrorCode, tag);
        }

        #endregion

        #region FACT
        [Fact]
        public void Should_not_have_error_when_tagname_is_specified()
        {
            var tag = new CreateTag
            {
                TagName = "fluentvalidation",
            };
            var result = new CreateTagValidator().TestValidate(tag);
            result.ShouldNotHaveValidationErrorFor(t => t.TagName);
        }
        [Fact]
        public async void Should_CreateTag_when_NoValidation()
        {
            // Arrange
            var tag = new CreateTag("aspnetcore_environment");

            // Act
            var tagEntity = _mapper?.Map<Ent.Tag>(tag);

            // ASSERT 
            Assert.NotNull(tagEntity);

            // Act
            bool result = await new DAL.Repositories.RepositoryDbContext<Ent.Tag>(ctx).Add(_mapper?.Map<Ent.Tag>(tag)!);

            // ASSERT 
            Assert.True(result);

        }

        [Fact]
        public async Task Should_CreateTag_when_Validation()
        {
            // Arrange
            var tag = new CreateTag("aspnetcore");

            var val = new CreateTagValidator().Validate(tag);

            // ASSERT 
            Assert.True(val.IsValid);

            if (val.IsValid)
            {
                // Act
                var tagEntity = _mapper?.Map<Ent.Tag>(tag);

                // ASSERT 
                Assert.NotNull(tagEntity);

                // Act
                bool result = await new DAL.Repositories.RepositoryDbContext<Ent.Tag>(ctx).Add(_mapper?.Map<Ent.Tag>(tag)!);

                // ASSERT 
                Assert.True(result);
            }
        }
        #endregion

    }
}
