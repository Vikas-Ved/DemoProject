using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAPIDemoApp.Commands;
using WebAPIDemoApp.Data;
using WebAPIDemoApp.Models;
using WebAPIDemoApp.Repositories.Interface;
using WebAPIDemoApp.Response;

namespace WebAPIDemoApp.Repositories.Implementation
{
    public class CourseRepository : ICourseRepository
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;
        public CourseRepository(DatabaseContext databaseContext, IMapper mapper)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
        }

        public async Task<CreateCourseResponse> AddCourse(CreateCourseCommand course)
        {
            var createCourse = _mapper.Map<Course>(course);
            var result = _databaseContext.Courses.Add(createCourse);
            await _databaseContext.SaveChangesAsync();

            if (course.StudentsList.Count > 0)
            {
                foreach (var item in course.StudentsList)
                {
                    var createStudent = _mapper.Map<Student>(item);
                    var getstudent = _databaseContext.Students.Where(s => s.StudentName == createStudent.StudentName).FirstOrDefault();

                    if (getstudent != null) 
                    {
                        var obj = new StudentCourse()
                        {
                            CourseId = result.Entity.CourseId,
                            StudentId = getstudent.StudentId
                        };
                        var res = _databaseContext.StudentCourses.Add(obj);
                        await _databaseContext.SaveChangesAsync();
                    }                    
                }
            }
            var ress = _mapper.Map<CreateCourseResponse>(result.Entity);
            return ress;
        }

        public async Task<UpdateCourseResponse> UpdateCourse(UpdateCourseCommand course)
        {
            var res = _databaseContext.Courses.Any(c => c.CourseId == course.CourseId);

            if (!res)
            {
                return default;
            }
            else
            {
                var updateres = _mapper.Map<Course>(course);

                var result = _databaseContext.Courses.Update(updateres);
                await _databaseContext.SaveChangesAsync();

                if (course.StudentsList.Count > 0)
                {
                    var mapres = _databaseContext.StudentCourses.Where(sc => sc.CourseId == updateres.CourseId).ToList();
                    foreach (var i in mapres)
                    {
                        var removeres = _databaseContext.StudentCourses.Remove(i);
                        await _databaseContext.SaveChangesAsync();
                    }

                    foreach (var item in course.StudentsList)
                    {
                        var getstudent = _databaseContext.Students.Where(s => s.StudentName == item.StudentName).FirstOrDefault();
                        if (getstudent != null)
                        {
                            var objt = new StudentCourse()
                            {
                                CourseId = result.Entity.CourseId,
                                StudentId = getstudent.StudentId
                            };
                            var createStudentCourse = _databaseContext.StudentCourses.Add(objt);
                            await _databaseContext.SaveChangesAsync();
                        }
                    }
                }
                var ress = _mapper.Map<UpdateCourseResponse>(result.Entity);
                return ress;
            }
        }
        
        public async Task<int> RemoveCourse(int id)
        {
            if (id == 0)
            {
                return default;
            }
            else 
            {
                var filterData = _databaseContext.Courses.Include(c => c.StudentCourses).Where(c => c.CourseId == id).FirstOrDefault();
                if (filterData != null && filterData.StudentCourses.Count > 0)
                {
                    foreach (var item in filterData.StudentCourses)
                    {
                        var removeEntry = _databaseContext.StudentCourses.Remove(item);
                        await _databaseContext.SaveChangesAsync();
                    }
                }
                
                var res = _databaseContext.Courses.Remove(filterData);
                await _databaseContext.SaveChangesAsync();
                return res.Entity.CourseId;
                
            }
        }

        public async Task<Course> GetStudentListByCourseId(int id)
        {
            var response = await _databaseContext.Courses.Include(c => c.StudentCourses)
                .ThenInclude(c => c.Student).Where(c => c.CourseId == id).FirstOrDefaultAsync();
            if (response == null) 
            {
                return null;
            }
            return response;
        }

        public async Task<List<Course>> GetCourseList()
        {
            return await _databaseContext.Courses.ToListAsync();
        }
    }
}
