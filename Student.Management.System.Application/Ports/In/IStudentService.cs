using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Student.Management.System.Domain.Entities;
using Student.Management.System.Domain.Entities.Dto;

namespace Student.Management.System.Application.Ports.In
{
    public interface IStudentService
    {
        public Task<GetStudentDto> AddStudent(AddStudentDto studentDto);
        Task<List<GetStudentDto>> DeleteMultiple(string ids);
        Task<GetStudentDto> DeleteSingle(int id);
        public List<StudentDetails> GetAllStudents();
        Task<IEnumerable<GetStudentDto>> GetAllStudentsByDapper();
        Task<GetStudentDto> UpdateStudent(GetStudentDto student);
    }
}