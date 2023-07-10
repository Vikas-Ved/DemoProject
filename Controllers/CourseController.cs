using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Net;
using WebAPIDemoApp.Commands;
using WebAPIDemoApp.Data;
using WebAPIDemoApp.Models;
using WebAPIDemoApp.Queries;
using WebAPIDemoApp.Repositories.Interface;
using WebAPIDemoApp.Response;
using WebAPIDemoApp.Validator;

namespace WebAPIDemoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly DatabaseContext _databaseContext;

        public CourseController(ISender sender, DatabaseContext databaseContext)
        {
            _sender = sender;
            _databaseContext = databaseContext;
        }

        [HttpGet]
        public async Task<List<CourseListProperty>> GetCourseList()
        {
            var courseList = await _sender.Send(new GetCourseListQuery());
            return courseList;
        }

        [HttpPost]
        public async Task<IActionResult> AddCourse(CreateCourseCommand course)
        {
            var studentList = _databaseContext.Students.ToList();
            var courseValidator = new CreateCourseCommandValidator(studentList);
            var result = courseValidator.Validate(course);
            if (!result.IsValid)
            {
                return BadRequest(result);
            }
            else
            {
                var response = await _sender.Send(course);
                return Ok(response);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCourse(UpdateCourseCommand course)
        {
            var studentList = _databaseContext.Students.ToList();
            var courseValidator = new UpdateCourseCommandValidator(studentList);
            var result = courseValidator.Validate(course);
            if (!result.IsValid)
            {
                return BadRequest(result);
            }
            else
            {
                var response = await _sender.Send(course);
                return Ok(response);
            }
        }

        [HttpDelete]
        public async Task<int> RemoveCourse(int courseId)
        {
            var res = await _sender.Send(new RemoveCourseCommand() { CourseId = courseId });
            return res;
        }


        [HttpGet]
        [Route("{courseId}")]
        public async Task<GetStudentListByCourseIdResponse> GetStudentListByCourseId(int courseId)
        {
            var query = new GetStudentListByCourseIdQuery { CourseId = courseId };
            var response = await _sender.Send(query);
            return response;
        }
    }
}