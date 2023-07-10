using MediatR;
using WebAPIDemoApp.Response;

namespace WebAPIDemoApp.Commands
{
    public class UpdateSubjectCommand : IRequest<UpdateSubjectResponse>

    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
    }
}
