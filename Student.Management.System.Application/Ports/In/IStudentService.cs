using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Student.Management.System.Domain.Entities;

namespace Student.Management.System.Application.Ports.In
{
    public interface IStudentService
    {
        public List<StudentDetails> GetAllStudents();
    }
}