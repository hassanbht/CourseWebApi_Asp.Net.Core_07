using CourseWebApi.Model.Tags.Commands;
using FluentValidation;

namespace CourseWebApi.Model.Tags.Validations
{
    public class CreateTagValidator : AbstractValidator<CreateTag>
    {
        public CreateTagValidator()
        {
            RuleFor(x => x.TagName)
              .Cascade(CascadeMode.Stop)
              .NotEmpty()
              .WithErrorCode("100").WithMessage("Name is not Empty")
              .MaximumLength(50)
              .WithErrorCode("101").WithMessage("Name is too long. The maximum length is 50")
              .MinimumLength(2)
              .WithErrorCode("102").WithMessage("Name is too short. The minimum length is 2");
        }
    }
}
