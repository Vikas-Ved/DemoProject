using WebAPIDemoApp.Models;

namespace WebAPIDemoApp.Response
{
    public class GetCourseListByStudentIdResponse
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentEmail { get; set;}
        public string StudentPhone { get; set;}
        public string StudentCity { get; set; }
        public ICollection<GetCourseListProperty> CourseList { get; set; }
    }
}
