using MediatR;

namespace WebAPIDemoApp.Commands
{
    public class RemoveSubjectCommand : IRequest<int>
    {
        public int SubjectId { get; set; }
    }
}
