using MediatR;
using WebAPIDemoApp.Commands;
using WebAPIDemoApp.Repositories.Interface;

namespace WebAPIDemoApp.Handlers
{
    public class RemoveSubjectHandler : IRequestHandler<RemoveSubjectCommand, int>
    {
        private readonly ISubjectRepository _subjectRepository;

        public RemoveSubjectHandler(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        public async Task<int> Handle(RemoveSubjectCommand request, CancellationToken cancellationToken)
        {
            var response = await _subjectRepository.RemoveSubject(request.SubjectId);
            return response;
        }
    }
}
