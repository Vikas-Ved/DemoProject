using MediatR;

namespace WebAPIDemoApp.Commands
{
    public class RemoveStudentCommand : IRequest<int>
    {
        public int StudentId { get; set; }
    }
}
