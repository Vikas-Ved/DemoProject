using AutoMapper;
using WebAPIDemoApp.Commands;
using WebAPIDemoApp.Models;
using WebAPIDemoApp.Response;

namespace WebAPIDemoApp.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<CreateCourseCommand,Course>().ReverseMap();
            CreateMap<Course,CreateCourseResponse>().ReverseMap();
            CreateMap<UpdateCourseCommand, Course>().ReverseMap();
            CreateMap<Course, UpdateCourseResponse>().ReverseMap();

            CreateMap<CreateStudentCommand, Student>().ReverseMap();
            CreateMap<Student, CreateStudentResponse>().ReverseMap();
            CreateMap<UpdateStudentCommand, Student>().ReverseMap();
            CreateMap<Student, UpdateStudentResponse>().ReverseMap();

            CreateMap<CreateSubjectCommand,Subject>().ReverseMap();
            CreateMap<Subject,CreateSubjectResponse>().ReverseMap();
            CreateMap<UpdateSubjectCommand, Subject>().ReverseMap();
            CreateMap<Subject, UpdateSubjectResponse>().ReverseMap();

            CreateMap<Student, GetCourseListByStudentIdResponse>().ReverseMap();
            CreateMap<StudentCourse, CourseListProperty>()
                .ForMember(dest => dest.CourseName, opt => opt.MapFrom(src => src.Course.CourseName))
                .ForMember(dest => dest.CourseDescription, opt => opt.MapFrom(src => src.Course.CourseDescription)).ReverseMap();
            CreateMap<Course, GetStudentListByCourseIdResponse>().ReverseMap();
            CreateMap<StudentCourse, StudentListProperty>()
                .ForMember(dest => dest.StudentName, opt => opt.MapFrom(src => src.Student.StudentName))
                .ForMember(dest => dest.StudentEmail, opt => opt.MapFrom(src => src.Student.StudentEmail))
                .ForMember(dest => dest.StudentPhone, opt => opt.MapFrom(src => src.Student.StudentPhone))
                .ForMember(dest => dest.StudentCity, opt => opt.MapFrom(src => src.Student.StudentCity))
                .ReverseMap();

            CreateMap<Student,StudentListProperty>().ReverseMap();
            CreateMap<Course, CourseListProperty>().ReverseMap();
            CreateMap<Subject, SubjectListProperty>().ReverseMap();

            CreateMap<StudentCourse, GetCourseListProperty>()
                .ForMember(dest => dest.CourseId, opt => opt.MapFrom(src => src.CourseId))
                .ForMember(dest => dest.CourseName, opt => opt.MapFrom(src => src.Course.CourseName))
                .ForMember(dest => dest.CourseDescription, opt => opt.MapFrom(src => src.Course.CourseDescription))
                .ReverseMap();
            CreateMap<StudentCourse, GetStudentListProperty>()
                .ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => src.Student.StudentId))
                .ForMember(dest => dest.StudentName, opt => opt.MapFrom(src => src.Student.StudentName))
                .ForMember(dest => dest.StudentEmail, opt => opt.MapFrom(src => src.Student.StudentEmail))
                .ForMember(dest => dest.StudentPhone, opt => opt.MapFrom(src => src.Student.StudentPhone))
                .ForMember(dest => dest.StudentCity, opt => opt.MapFrom(src => src.Student.StudentCity))
                .ReverseMap();
        }
    }
}
