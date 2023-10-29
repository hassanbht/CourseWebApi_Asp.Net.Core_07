using AutoMapper;
using CourseWebApi.Model.Courses.Entities;
using CourseWebApi.Model.Repositories;
using CourseWebApi.Model.Services;
using CourseWebApi.Model.Student.Dtos;
using CourseWebApi.Model.Student.Entities;
using Microsoft.Extensions.Logging;

namespace CourseWebApi.BLL.Students
{
    public class StudentService : IStudentService
    {
        private readonly IRepository<Student> _studentRepository;
        private readonly IMapper _mapper;

        public StudentService(IRepository<Student> studentRepository, IMapper mapper)
        {
            this._studentRepository = studentRepository;
            this._mapper = mapper;
        }
        public async Task<int> CreateAsync(StudentModel student)
        {
            Student studentEntity = new Student
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                Description = student.Description,
                StudentNumber = student.StudentNumber,
                PhoneNumbers = student.PhoneNumbers.Select(p => _mapper.Map<PhoneNumber>(p) 
                //{
                //    Number = p.Number
                //}
                ).ToList(),
                Courses = student?.Courses?.Select(c => _mapper.Map<Course>(c) 
                ).ToList(),
                //{
                //    Id = c.CourseId,
                //    Title = c.Title,
                //    Description = c.Description,
                //    ImageUrl = c.ImageUrl,
                //    Price = c.Price,
                //    ShortDescription = c.ShortDescription,
                //    StartDate = c.StartDate,
                //    EndTime = c.EndTime,
                //    CourseTags = c.Tags.Select(t => _mapper.Map<CourseTag>(t)
                //    //{
                //    //    CourseId = c.CourseId,
                //    //    TagId = t.Id,
                //    //}
                //    ).ToList(),
                //    CourseTeachers = c.Teachers.Select(t => _mapper.Map<CourseTeacher>(t)
                //    //{
                //    //    CourseId = c.CourseId,
                //    //    TeacherId = t.TeacherId,
                //    //}
                //    ).ToList(),
                //    CourseComments = c.Comments.Select(cm => _mapper.Map<CourseComment>(cm)
                //    //{
                //    //    Id = cm.CommentId,
                //    //    CommantDate = cm.CommantDate,
                //    //    CommentBy = cm.CommentBy,
                //    //    Comment = cm.Comment,
                //    //    CourseId = c.CourseId,
                //    //    IsValid = cm.IsValid
                //    //}
                //    ).ToList(),
                //    RowVersion = c.RowVersion,

                //}).ToList()
            };

           await _studentRepository.AddAsync(studentEntity,CancellationToken.None);
            return await Task.FromResult(studentEntity.Id);
        }

        public Task<bool> DeleteAsync(int id)
        {
            var student = new Student
            {
                Id = id,
            };
            var result = _studentRepository.Delete(student);
            return result;
        }

        public async Task<IEnumerable<StudentModel>> GetAllAsync()
        {
            var result = await _studentRepository.GetAll(s => s.PhoneNumbers, s => s.Courses!);
            return result.Select(c => _mapper.Map<StudentModel>(c)).ToList();

        }

        public async Task<StudentModel> GetByIdAsync(int id)
        {
            return _mapper.Map<StudentModel>(await _studentRepository.GetById(id, s => s.PhoneNumbers, s => s.Courses!));
        }

        public async Task<bool> UpdateAsync(StudentModel student)
        {
            Student studentEntity = new Student
            {
                Id=student.StudentId,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Description = student.Description,
                StudentNumber = student.StudentNumber,
                PhoneNumbers = student.PhoneNumbers.Select(p => _mapper.Map<PhoneNumber>(p)
               ).ToList(),
                Courses = student?.Courses?.Select(c => _mapper.Map<Course>(c)
               ).ToList(),
                
            };


            return await _studentRepository.Update(studentEntity);
        }
    }
}
