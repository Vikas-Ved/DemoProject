using MediatR;
using WebAPIDemoApp.Response;

namespace WebAPIDemoApp.Commands
{
    public class CreateSubjectCommand : IRequest<CreateSubjectResponse>
    {
        public string SubjectName { get; set; }
    }
}
