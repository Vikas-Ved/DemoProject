using MediatR;
using WebAPIDemoApp.Response;

namespace WebAPIDemoApp.Queries
{
    internal class GetStudentListByCourseIdQuery : IRequest<GetStudentListByCourseIdResponse>
    {
        public int CourseId { get; set; }
    }
}