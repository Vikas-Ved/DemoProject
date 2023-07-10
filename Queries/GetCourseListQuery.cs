using MediatR;
using WebAPIDemoApp.Models;

namespace WebAPIDemoApp.Queries
{
    public class GetCourseListQuery : IRequest<List<CourseListProperty>>
    {
    }
}
