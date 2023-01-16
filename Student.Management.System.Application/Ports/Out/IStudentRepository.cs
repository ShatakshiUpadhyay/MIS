using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Student.Management.System.Domain.Entities;
using Student.Management.System.Domain.Entities.Dto;

namespace Student.Management.System.Application.Ports.Out
{
    public interface IStudentRepository
    {
        Task<GetStudentDto> DeleteSingle(int id);
        IEnumerable<StudentDetails> GetStudents();

        Task<StudentDetails> InsertStudent(StudentDetails student);

    }
}