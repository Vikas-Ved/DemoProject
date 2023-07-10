namespace WebAPIDemoApp.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public ICollection<CourseSubject> CourseSubjects { get; set; }
    }
}
