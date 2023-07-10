using FluentValidation;
using WebAPIDemoApp.Commands;
using WebAPIDemoApp.Models;

namespace WebAPIDemoApp.Validator
{
    public class CreateCourseCommandValidator : AbstractValidator<CreateCourseCommand>
    {
        public CreateCourseCommandValidator(List<Student> studentList)
        {
            RuleFor(c => c.CourseName).NotNull().NotEmpty().MaximumLength(30);
            RuleFor(c => c.CourseDescription).NotNull().NotEmpty().MinimumLength(15).MaximumLength(50);
            RuleForEach(c => c.StudentsList).SetValidator(new CreateStudentListValidator(studentList));
        }
    }
}
