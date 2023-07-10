using AutoMapper;
using MediatR;
using WebAPIDemoApp.Models;
using WebAPIDemoApp.Queries;
using WebAPIDemoApp.Repositories.Implementation;
using WebAPIDemoApp.Repositories.Interface;
using WebAPIDemoApp.Response;

namespace WebAPIDemoApp.Handlers
{
    public class GetStudentListByCourseIdHandler : IRequestHandler<GetStudentListByCourseIdQuery, GetStudentListByCourseIdResponse>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public GetStudentListByCourseIdHandler(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        async Task<GetStudentListByCourseIdResponse> IRequestHandler<GetStudentListByCourseIdQuery, GetStudentListByCourseIdResponse>.Handle(GetStudentListByCourseIdQuery request, CancellationToken cancellationToken)
        {
            var response = await _courseRepository.GetStudentListByCourseId(request.CourseId);
            var createResponse = _mapper.Map<GetStudentListByCourseIdResponse>(response);
            createResponse.StudentList = response.StudentCourses.Select(x => _mapper.Map<GetStudentListProperty>(x)).ToList();
            return createResponse;
        }
    }
}
