using AutoMapper;
using MediatR;
using WebAPIDemoApp.Commands;
using WebAPIDemoApp.Models;
using WebAPIDemoApp.Repositories.Implementation;
using WebAPIDemoApp.Repositories.Interface;
using WebAPIDemoApp.Response;

namespace WebAPIDemoApp.Handlers
{
    public class UpdateStudentHandler : IRequestHandler<UpdateStudentCommand, UpdateStudentResponse>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        public UpdateStudentHandler(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<UpdateStudentResponse> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {            
            var response = await _studentRepository.UpdateStudent(request);
            return response;
        }
    }
}
