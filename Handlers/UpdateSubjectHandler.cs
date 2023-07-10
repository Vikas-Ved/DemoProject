using AutoMapper;
using MediatR;
using WebAPIDemoApp.Commands;
using WebAPIDemoApp.Models;
using WebAPIDemoApp.Repositories.Implementation;
using WebAPIDemoApp.Repositories.Interface;
using WebAPIDemoApp.Response;

namespace WebAPIDemoApp.Handlers
{
    public class UpdateSubjectHandler : IRequestHandler<UpdateSubjectCommand, UpdateSubjectResponse>
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly IMapper _mapper;
        public UpdateSubjectHandler(ISubjectRepository subjectRepository, IMapper mapper)
        {
            _subjectRepository = subjectRepository;
            _mapper = mapper;
        }

        public async Task<UpdateSubjectResponse> Handle(UpdateSubjectCommand request, CancellationToken cancellationToken)
        {
            var updatesubject = _mapper.Map<Subject>(request);            
            var response = await _subjectRepository.UpdateSubject(updatesubject);
            var createResponse = _mapper.Map<UpdateSubjectResponse>(response);
            return createResponse;
        }
    }
}
