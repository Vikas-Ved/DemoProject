using MediatR;

namespace WebAPIDemoApp.Commands
{
    public class RemoveCourseCommand : IRequest<int>
    {
        public int CourseId { get; set; }
    }
}
