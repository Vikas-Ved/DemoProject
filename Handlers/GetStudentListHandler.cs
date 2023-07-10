using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Razor.TagHelpers;
using WebAPIDemoApp.Models;
using WebAPIDemoApp.Queries;
using WebAPIDemoApp.Repositories.Interface;

namespace WebAPIDemoApp.Handlers
{
    public class GetStudentListHandler : IRequestHandler<GetStudentListQuery, List<StudentListProperty>>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public GetStudentListHandler(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<List<StudentListProperty>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            var response = await _studentRepository.GetStudentList();
            var getResponse = _mapper.Map<List<StudentListProperty>>(response);
            return getResponse;
        }
    }
}
