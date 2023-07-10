using WebAPIDemoApp.Commands;
using WebAPIDemoApp.Models;
using WebAPIDemoApp.Response;

namespace WebAPIDemoApp.Repositories.Interface
{
    public interface ICourseRepository
    {
        public Task<CreateCourseResponse> AddCourse(CreateCourseCommand course);
        public Task<UpdateCourseResponse> UpdateCourse(UpdateCourseCommand course);
        public Task<int> RemoveCourse(int courseId);
        public Task<Course> GetStudentListByCourseId(int courseId);
        public Task<List<Course>> GetCourseList();
    }
}
