using WebAPIDemoApp.Models;

namespace WebAPIDemoApp.Repositories.Interface
{
    public interface ISubjectRepository
    {
        public Task<Subject> AddSubject(Subject subject);
        public Task<Subject> UpdateSubject(Subject subject);
        public Task<int> RemoveSubject(int subjectId);
        public Task<List<Subject>> GetSubjectList();
    }
}
