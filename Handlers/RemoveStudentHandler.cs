using MediatR;
using WebAPIDemoApp.Commands;
using WebAPIDemoApp.Repositories.Interface;

namespace WebAPIDemoApp.Handlers
{
    public class RemoveStudentHandler : IRequestHandler<RemoveStudentCommand, int>
    {
        private readonly IStudentRepository _studentRepository;

        public RemoveStudentHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<int> Handle(RemoveStudentCommand request, CancellationToken cancellationToken)
        {
            var response = await _studentRepository.RemoveStudent(request.StudentId);
            return response;
        }
    }
}
