using Microsoft.EntityFrameworkCore;
using WebAPIDemoApp.Data;
using WebAPIDemoApp.Models;
using WebAPIDemoApp.Repositories.Interface;

namespace WebAPIDemoApp.Repositories.Implementation
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly DatabaseContext _databaseContext;
        public SubjectRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<Subject> AddSubject(Subject subject)
        {
            var result = _databaseContext.Subjects.Add(subject);
            await _databaseContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Subject> UpdateSubject(Subject subject)
        {
            var res = _databaseContext.Subjects.Where(s => s.SubjectId == subject.SubjectId).FirstOrDefault();

            if (res != null)
            {
                res.SubjectId = subject.SubjectId;
                res.SubjectName = subject.SubjectName;
   
                var result = _databaseContext.Subjects.Update(res);
                await _databaseContext.SaveChangesAsync();
                return result.Entity;
            }
            return null;
        }

        public async Task<int> RemoveSubject(int id)
        {
            if (id == 0)
            {
                return default;
            }
            else 
            {
                var filterData = _databaseContext.Subjects.Include(s => s.CourseSubjects).Where(s => s.SubjectId == id).FirstOrDefault();
                if (filterData.CourseSubjects.Count > 0 || id == 0)
                {
                    return default;
                }
                else
                {
                    var res = _databaseContext.Subjects.Remove(filterData);
                    await _databaseContext.SaveChangesAsync();
                    return res.Entity.SubjectId;
                }
            }
        }

        public async Task<List<Subject>> GetSubjectList()
        {
            return await _databaseContext.Subjects.ToListAsync();
        }
    }
}
