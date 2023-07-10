using AutoMapper;
using MediatR;
using WebAPIDemoApp.Commands;
using WebAPIDemoApp.Models;
using WebAPIDemoApp.Repositories.Implementation;
using WebAPIDemoApp.Repositories.Interface;
using WebAPIDemoApp.Response;

namespace WebAPIDemoApp.Handlers
{
    public class UpdateCourseHandler : IRequestHandler<UpdateCourseCommand, UpdateCourseResponse>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;
        public UpdateCourseHandler(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public async Task<UpdateCourseResponse> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {            
            var response = await _courseRepository.UpdateCourse(request);
            return response;
        }
    }
}
