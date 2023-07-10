using AutoMapper;
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using WebAPIDemoApp.Commands;
using WebAPIDemoApp.Data;
using WebAPIDemoApp.Models;
using WebAPIDemoApp.Repositories.Interface;
using WebAPIDemoApp.Response;

namespace WebAPIDemoApp.Repositories.Implementation
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;
        public StudentRepository(DatabaseContext databaseContext, IMapper mapper)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
        }

        public async Task<CreateStudentResponse> AddStudent(CreateStudentCommand student)
        {
            var createStudent = _mapper.Map<Student>(student);
            var result = _databaseContext.Students.Add(createStudent);
            await _databaseContext.SaveChangesAsync();

            if (student.CoursesList.Count > 0) 
            {
                foreach (var item in student.CoursesList) 
                {
                    var createCourse = _mapper.Map<Course>(item);
                    var getcourse = _databaseContext.Courses.Where(c => c.CourseName == createCourse.CourseName).FirstOrDefault();

                    if (getcourse != null) 
                    {
                        var obj = new StudentCourse()
                        {
                            StudentId = result.Entity.StudentId,
                            CourseId = getcourse.CourseId
                        };
                        var res = _databaseContext.StudentCourses.Add(obj);
                        await _databaseContext.SaveChangesAsync();
                    }                    
                }
            }
            
            var ress = _mapper.Map<CreateStudentResponse>(result.Entity);
            return ress;
        }

        public async Task<UpdateStudentResponse> UpdateStudent(UpdateStudentCommand student)
        {
            var res = _databaseContext.Students.Any(s => s.StudentId == student.StudentId);

            if (!res) 
            {
                return default;
            }
            else
            {
                var updateres = _mapper.Map<Student>(student);
                
                var result = _databaseContext.Students.Update(updateres);
                await _databaseContext.SaveChangesAsync();

                if (student.CoursesList.Count > 0)
                {
                    var mapres = _databaseContext.StudentCourses.Where(sc => sc.StudentId == updateres.StudentId).ToList();
                    foreach (var i in mapres) 
                    {
                        var removeres = _databaseContext.StudentCourses.Remove(i);
                        await _databaseContext.SaveChangesAsync();
                    }                    

                    foreach (var item in student.CoursesList)
                    {
                        var getcourse = _databaseContext.Courses.Where(c => c.CourseName == item.CourseName).FirstOrDefault();
                        if (getcourse != null) 
                        { 
                            var objt = new StudentCourse()
                            {
                                StudentId = result.Entity.StudentId,
                                CourseId = getcourse.CourseId,
                            };
                            var createStudentCourse = _databaseContext.StudentCourses.Add(objt);
                            await _databaseContext.SaveChangesAsync();
                        }
                    }
                }
                var ress = _mapper.Map<UpdateStudentResponse>(result.Entity);
                return ress;
            }
        }

        public async Task<int> RemoveStudent(int id)
        {
            if (id == 0)
            {
                return default;
            }
            else 
            {
                var filterData = _databaseContext.Students.Include(s => s.StudentCourses).Where(x => x.StudentId == id).FirstOrDefault();
                if (filterData != null && filterData.StudentCourses.Count > 0)
                {
                    foreach (var item in filterData.StudentCourses) 
                    {
                        var removeEntry = _databaseContext.StudentCourses.Remove(item);
                        await _databaseContext.SaveChangesAsync();
                    }
                }
                
                var res = _databaseContext.Students.Remove(filterData);
                await _databaseContext.SaveChangesAsync();
                return res.Entity.StudentId;
            }
        }

        public async Task<Student> GetCourseListByStudentId(int id)
        {
            var response = await _databaseContext.Students.Include(s => s.StudentCourses)
                .ThenInclude(s => s.Course).Where(s => s.StudentId == id).FirstOrDefaultAsync();
            if (response == null) 
            {
                return null;
            }
            return response;
        }

        public async Task<List<Student>> GetStudentList()
        {
            return await _databaseContext.Students.ToListAsync();
        }
    }
}
