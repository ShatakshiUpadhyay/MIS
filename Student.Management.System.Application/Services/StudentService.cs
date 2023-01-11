using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Student.Management.System.Application.Ports.In;
using Student.Management.System.Domain.Entities;

namespace Student.Management.System.Application.Services
{
    public class StudentService : IStudentService
    {
        public List<StudentDetails> GetAllStudents()
        {
            return new List<StudentDetails>();
        }
    }
}