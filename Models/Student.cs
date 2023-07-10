namespace WebAPIDemoApp.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentEmail { get; set;}
        public string StudentPhone { get; set;}
        public string StudentCity { get; set;}
        public ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
