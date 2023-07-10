using AutoMapper;
using MediatR;
using WebAPIDemoApp.Models;
using WebAPIDemoApp.Queries;
using WebAPIDemoApp.Repositories.Interface;

namespace WebAPIDemoApp.Handlers
{
    public class GetCourseListHandler : IRequestHandler<GetCourseListQuery, List<CourseListProperty>>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public GetCourseListHandler(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public async Task<List<CourseListProperty>> Handle(GetCourseListQuery request, CancellationToken cancellationToken)
        {
            var response = await _courseRepository.GetCourseList();
            var getResponse = _mapper.Map<List<CourseListProperty>>(response);
            return getResponse;
        }
    }
}
