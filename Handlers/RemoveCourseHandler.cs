using MediatR;
using WebAPIDemoApp.Commands;
using WebAPIDemoApp.Repositories.Interface;

namespace WebAPIDemoApp.Handlers
{
    public class RemoveCourseHandler : IRequestHandler<RemoveCourseCommand, int>
    {
        private readonly ICourseRepository _courseRepository;

        public RemoveCourseHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<int> Handle(RemoveCourseCommand request, CancellationToken cancellationToken)
        {
            var response = await _courseRepository.RemoveCourse(request.CourseId);
            return response;
        }
    }
}
