using MediatR;
using WebAPIDemoApp.Models;
using WebAPIDemoApp.Response;

namespace WebAPIDemoApp.Queries
{
    public class GetCourseListByStudentIdQuery : IRequest<GetCourseListByStudentIdResponse>
    {
        public int StudentId { get; set; }
    }
}
