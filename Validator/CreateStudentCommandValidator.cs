using FluentValidation;
using WebAPIDemoApp.Commands;
using WebAPIDemoApp.Models;

namespace WebAPIDemoApp.Validator
{
    public class CreateStudentCommandValidator : AbstractValidator<CreateStudentCommand>
    {
        public CreateStudentCommandValidator(List<Course> courseList) 
        {
            RuleFor(s => s.StudentName).NotNull().NotEmpty().MaximumLength(20);
            RuleFor(s => s.StudentEmail).NotEmpty().EmailAddress();
            RuleFor(s => s.StudentPhone).NotEmpty().Length(10).Matches("^[0-9]*$").When(s => !string.IsNullOrEmpty(s.StudentPhone));
            RuleFor(s => s.StudentCity).NotNull().NotEmpty();
            RuleForEach(s => s.CoursesList).SetValidator(new CreateCourseListValidator(courseList));
        }
    }
}
