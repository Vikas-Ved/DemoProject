using MediatR;
using WebAPIDemoApp.Models;
using WebAPIDemoApp.Response;

namespace WebAPIDemoApp.Commands
{
    public class CreateCourseCommand : IRequest<CreateCourseResponse>

    {
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public ICollection<StudentListProperty> StudentsList { get; set; }
    }
}
