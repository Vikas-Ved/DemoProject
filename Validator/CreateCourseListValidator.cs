using FluentValidation;
using WebAPIDemoApp.Commands;
using WebAPIDemoApp.Models;

namespace WebAPIDemoApp.Validator
{
    public class CreateCourseListValidator : AbstractValidator<CourseListProperty>
    {
        private readonly List<Course> _course;
        public CreateCourseListValidator(List<Course> course)
        {
            _course = course;

            RuleFor(c => c.CourseName).MaximumLength(30).Must(x => IsExistCourseName(x)).WithMessage("{PropertyName} must match with any course in course list." );
            RuleFor(c => c.CourseDescription).MinimumLength(15).MaximumLength(50);
        }

        public bool IsExistCourseName(string coursename)
        {
            var flag = false;
            foreach (var item in _course)
            {
                if (coursename != item.CourseName)
                {
                    flag = false;
                }
                else
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }
    }
}
