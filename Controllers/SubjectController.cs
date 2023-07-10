using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIDemoApp.Commands;
using WebAPIDemoApp.Models;
using WebAPIDemoApp.Queries;
using WebAPIDemoApp.Validator;

namespace WebAPIDemoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISender _sender;

        public SubjectController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<List<SubjectListProperty>> GetSubjectList()
        {
            var subjectList = await _sender.Send(new GetSubjectListQuery());
            return subjectList;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubject(CreateSubjectCommand subject)
        {
            var subjectValidator = new CreateSubjectCommandValidator();
            var result = subjectValidator.Validate(subject);
            if (!result.IsValid)
            {
                return BadRequest(result);
            }
            else
            {
                var response = await _sender.Send(subject);
                return Ok(response);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSubject(UpdateSubjectCommand subject)
        {
            var subjectValidator = new UpdateSubjectCommandValidator();
            var result = subjectValidator.Validate(subject);
            if (!result.IsValid)
            {
                return BadRequest(result);
            }
            else
            {
                var response = await _sender.Send(subject);
                return Ok(response);
            }
        }

        [HttpDelete]
        public async Task<int> RemoveSubject(int subjectId)
        {
            var res = await _sender.Send(new RemoveSubjectCommand() { SubjectId = subjectId });
            return res;
        }
    }
}
