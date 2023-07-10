using MediatR;
using WebAPIDemoApp.Models;

namespace WebAPIDemoApp.Queries
{
    public class GetSubjectListQuery : IRequest<List<SubjectListProperty>>
    {
    }
}
