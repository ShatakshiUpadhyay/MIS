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
        public Task<List<GetStudentDto>> AddStudent(AddStudentDto studentDto);
        public List<StudentDetails> GetAllStudents();
    }
}