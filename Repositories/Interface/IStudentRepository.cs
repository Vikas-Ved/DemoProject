using WebAPIDemoApp.Commands;
using WebAPIDemoApp.Models;
using WebAPIDemoApp.Response;

namespace WebAPIDemoApp.Repositories.Interface
{
    public interface IStudentRepository
    {
        public Task<CreateStudentResponse> AddStudent(CreateStudentCommand student);
        public Task<UpdateStudentResponse> UpdateStudent(UpdateStudentCommand student);
        public Task<int> RemoveStudent(int studentId);
        public Task<Student> GetCourseListByStudentId(int studentId);
        public Task<List<Student>> GetStudentList();
    }
}
