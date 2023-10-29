using CourseWebApi.Model.Tags.Commands;
using FluentValidation;

namespace CourseWebApi.Model.Tags.Validations
{
    public class InlineUpdateTagValidator : InlineValidator<UpdateTag>
    {
        public InlineUpdateTagValidator()
        {

        }

        public InlineUpdateTagValidator(params Action<InlineUpdateTagValidator>[] actions)
        {
            foreach (var action in actions)
            {
                action(this);
            }
        }
    }

}
