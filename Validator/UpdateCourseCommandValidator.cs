using FluentValidation;
using WebAPIDemoApp.Commands;
using WebAPIDemoApp.Models;

namespace WebAPIDemoApp.Validator
{
    public class UpdateCourseCommandValidator : AbstractValidator<UpdateCourseCommand>
    {
        public UpdateCourseCommandValidator(List<Student> studentList)
        {
            RuleFor(c => c.CourseId).NotEqual(0);
            RuleFor(c => c.CourseName).NotNull().NotEmpty().MaximumLength(30);
            RuleFor(c => c.CourseDescription).MinimumLength(15).MaximumLength(50);
            RuleForEach(c => c.StudentsList).SetValidator(new CreateStudentListValidator(studentList));
        }
    }
}
