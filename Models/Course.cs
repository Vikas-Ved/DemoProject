namespace WebAPIDemoApp.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public ICollection<CourseSubject> CourseSubjects { get; set; }
        public ICollection<StudentCourse> StudentCourses{ get; set; }
    }
}
