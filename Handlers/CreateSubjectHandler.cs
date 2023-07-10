using AutoMapper;
using MediatR;
using WebAPIDemoApp.Commands;
using WebAPIDemoApp.Models;
using WebAPIDemoApp.Repositories.Interface;
using WebAPIDemoApp.Response;

namespace WebAPIDemoApp.Handlers
{
    public class CreateSubjectHandler : IRequestHandler<CreateSubjectCommand, CreateSubjectResponse>
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly IMapper _mapper;
        public CreateSubjectHandler(ISubjectRepository subjectRepository, IMapper mapper)
        {
            _subjectRepository = subjectRepository;
            _mapper = mapper;
        }

        public async Task<CreateSubjectResponse> Handle(CreateSubjectCommand request, CancellationToken cancellationToken)
        {
            var createSubject = _mapper.Map<Subject>(request);
            var response = await _subjectRepository.AddSubject(createSubject);
            var createResponse = _mapper.Map<CreateSubjectResponse>(response);
            return createResponse;
        }
    }
}
