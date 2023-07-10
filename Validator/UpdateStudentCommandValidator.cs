using FluentValidation;
using WebAPIDemoApp.Commands;
using WebAPIDemoApp.Models;

namespace WebAPIDemoApp.Validator
{
    public class UpdateStudentCommandValidator : AbstractValidator<UpdateStudentCommand>
    {
        public UpdateStudentCommandValidator(List<Course> courselist) 
        {
            RuleFor(s => s.StudentId).NotEqual(0);
            RuleFor(s => s.StudentName).NotNull().NotEmpty().MaximumLength(20);
            RuleFor(s => s.StudentEmail).NotEmpty().EmailAddress();
            RuleFor(s => s.StudentPhone).NotEmpty().Length(10).Matches("^[0-9]*$").When(s => !string.IsNullOrEmpty(s.StudentPhone));
            RuleFor(s => s.StudentCity).NotNull().NotEmpty();
            RuleForEach(s => s.CoursesList).SetValidator(new CreateCourseListValidator(courselist));
        }
    }
}
