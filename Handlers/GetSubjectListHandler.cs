using AutoMapper;
using MediatR;
using WebAPIDemoApp.Models;
using WebAPIDemoApp.Queries;
using WebAPIDemoApp.Repositories.Interface;

namespace WebAPIDemoApp.Handlers
{
    public class GetSubjectListHandler : IRequestHandler<GetSubjectListQuery, List<SubjectListProperty>>
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly IMapper _mapper;

        public GetSubjectListHandler(ISubjectRepository subjectRepository, IMapper mapper)
        {
            _subjectRepository = subjectRepository;
            _mapper = mapper;
        }

        public async Task<List<SubjectListProperty>> Handle(GetSubjectListQuery request, CancellationToken cancellationToken)
        {
            var response = await _subjectRepository.GetSubjectList();
            var getResponse = _mapper.Map<List<SubjectListProperty>>(response);
            return getResponse;
        }
    }
}
