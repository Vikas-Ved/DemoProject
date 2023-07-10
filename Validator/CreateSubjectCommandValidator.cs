using FluentValidation;
using WebAPIDemoApp.Commands;

namespace WebAPIDemoApp.Validator
{
    public class CreateSubjectCommandValidator : AbstractValidator<CreateSubjectCommand>
    {
        public CreateSubjectCommandValidator()
        {
            RuleFor(s => s.SubjectName).MaximumLength(30);
        }
    }
}
