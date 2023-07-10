using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPIDemoApp.Commands;
using WebAPIDemoApp.Data;
using WebAPIDemoApp.Models;
using WebAPIDemoApp.Queries;
using WebAPIDemoApp.Response;
using WebAPIDemoApp.Validator;

namespace WebAPIDemoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly DatabaseContext _databaseContext;
        public StudentController(ISender sender, DatabaseContext databaseContext)
        {
            _sender = sender;
            _databaseContext = databaseContext;
        }

        [HttpGet]
        public async Task<List<StudentListProperty>> GetStudentList()
        {
            var studentList = await _sender.Send(new GetStudentListQuery());
            return studentList;
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent(CreateStudentCommand student)
        {
            var courseList = _databaseContext.Courses.ToList();
            var studentValidator = new CreateStudentCommandValidator(courseList);
            var result = studentValidator.Validate(student);
            if (!result.IsValid)
            {
                return BadRequest(result);
            }
            else
            {
                var response = await _sender.Send(student);
                return Ok(response);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStudent(UpdateStudentCommand student) 
        {
            var courseList = _databaseContext.Courses.ToList();
            var studentValidator = new UpdateStudentCommandValidator(courseList);
            var result = studentValidator.Validate(student);
            if (!result.IsValid)
            {
                return BadRequest(result);
            }
            else
            {
                var response = await _sender.Send(student);
                return Ok(response);
            }
        }

        [HttpDelete]
        public async Task<int> RemoveStudent(int studentId)
        {
            var res = await _sender.Send(new RemoveStudentCommand() { StudentId = studentId });
            return res;
        }

        [HttpGet]
        [Route("{studentId}")]
        public async Task<GetCourseListByStudentIdResponse> GetCourseListByStudentId(int studentId) 
        {
            var query = new GetCourseListByStudentIdQuery { StudentId = studentId };
            var response = await _sender.Send(query);
            return response;
        }
    }
}
