using FluentValidation;
using WebAPIDemoApp.Commands;
using WebAPIDemoApp.Models;

namespace WebAPIDemoApp.Validator
{
    public class CreateStudentListValidator : AbstractValidator<StudentListProperty>
    {
        private readonly List<Student> _student;
        public CreateStudentListValidator(List<Student> student)
        {
            _student = student;

            RuleFor(s => s.StudentName).MaximumLength(30).Must(x => IsExistStudentName(x)).WithMessage("{PropertyName} must match with any student in student list." );
            RuleFor(s => s.StudentEmail).NotEmpty().EmailAddress();
            RuleFor(s => s.StudentPhone).NotEmpty().Length(10).Matches("^[0-9]*$").When(s => !string.IsNullOrEmpty(s.StudentPhone));
            RuleFor(s => s.StudentCity).NotNull().NotEmpty();
        }

        public bool IsExistStudentName(string studentname)
        {
            var flag = false;
            foreach (var item in _student)
            {
                if (studentname != item.StudentName)
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
