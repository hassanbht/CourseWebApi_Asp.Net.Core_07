using CourseWebApi.Model.Student.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWebApi.Model.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentModel>> GetAllAsync();
        Task<StudentModel> GetByIdAsync(int id);
        Task<int> CreateAsync(StudentModel student);
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(StudentModel student);
    }
}
