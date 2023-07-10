using FluentValidation;
using WebAPIDemoApp.Commands;

namespace WebAPIDemoApp.Validator
{
    public class UpdateSubjectCommandValidator : AbstractValidator<UpdateSubjectCommand>
    {
        public UpdateSubjectCommandValidator()
        {
            RuleFor(s => s.SubjectId).NotEqual(0);
            RuleFor(s => s.SubjectName).MaximumLength(30);
        }
    }
}
