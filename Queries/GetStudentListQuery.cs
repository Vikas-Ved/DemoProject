using MediatR;
using WebAPIDemoApp.Models;

namespace WebAPIDemoApp.Queries
{
    public class GetStudentListQuery : IRequest<List<StudentListProperty>>
    {
    }
}
