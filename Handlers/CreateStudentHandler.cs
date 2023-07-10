using AutoMapper;
using MediatR;
using WebAPIDemoApp.Commands;
using WebAPIDemoApp.Models;
using WebAPIDemoApp.Repositories.Interface;
using WebAPIDemoApp.Response;

namespace WebAPIDemoApp.Handlers
{
    public class CreateStudentHandler : IRequestHandler<CreateStudentCommand, CreateStudentResponse>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        public CreateStudentHandler(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<CreateStudentResponse> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var response = await _studentRepository.AddStudent(request);
            return response;
        }
    }
}
