using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Student.Management.System.Domain.Entities;

namespace Student.Management.System.Application.Ports.Out
{
    public interface ISubjectRepository
    {
        ICollection<StudentDetails> GetStudentsWithSubject(int id);

    }
}