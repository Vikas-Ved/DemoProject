using WebAPIDemoApp.Models;

namespace WebAPIDemoApp.Response
{
    public class GetStudentListByCourseIdResponse
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public ICollection<GetStudentListProperty> StudentList { get; set; }
    }
}
