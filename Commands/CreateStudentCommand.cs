using MediatR;
using WebAPIDemoApp.Models;
using WebAPIDemoApp.Response;

namespace WebAPIDemoApp.Commands
{
    public class CreateStudentCommand : IRequest<CreateStudentResponse>
    {
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
        public string StudentPhone { get; set; }
        public string StudentCity { get; set; }
        public ICollection<CourseListProperty> CoursesList { get; set; }
    }
}
