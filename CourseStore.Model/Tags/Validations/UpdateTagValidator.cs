using CourseStore.Model.Tags.Commands;
using FluentValidation;

namespace CourseWebApi.Model.Tags.Validations
{
    public class UpdateTagValidator : AbstractValidator<UpdateTag>
    {
        public UpdateTagValidator()
        {
            RuleFor(x => x.TagName)
               .Cascade(CascadeMode.Stop)
               .NotEmpty()
               .WithErrorCode("100").WithMessage("Name is not Empty")
               .MaximumLength(50)
               .WithErrorCode("101").WithMessage("Name is too long. The maximum length is 50")
               .MinimumLength(2)
               .WithErrorCode("102").WithMessage("Name is too short. The minimum length is 2");

            RuleFor(x => x.TagId)
               .Cascade(CascadeMode.Stop)
               .NotEmpty()
               .WithErrorCode("100").WithMessage("Id is not Empty")
               .InclusiveBetween(1, int.MaxValue)
               .WithErrorCode("101");
        }
    }
}
