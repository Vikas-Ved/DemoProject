using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebAPIDemoApp.Data;
using WebAPIDemoApp.Models;
using WebAPIDemoApp.Queries;
using WebAPIDemoApp.Repositories.Implementation;
using WebAPIDemoApp.Repositories.Interface;
using WebAPIDemoApp.Response;

namespace WebAPIDemoApp.Handlers
{
    public class GetCourseListByStudentIdHandler : IRequestHandler<GetCourseListByStudentIdQuery, GetCourseListByStudentIdResponse>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        public GetCourseListByStudentIdHandler(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<GetCourseListByStudentIdResponse> Handle(GetCourseListByStudentIdQuery request, CancellationToken cancellationToken)
        {
            var response = await _studentRepository.GetCourseListByStudentId(request.StudentId);
            var createResponse = _mapper.Map<GetCourseListByStudentIdResponse>(response);
            createResponse.CourseList = response.StudentCourses.Select(x => _mapper.Map<GetCourseListProperty>(x)).ToList();
            return createResponse;
        }
    }
}
