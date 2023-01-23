using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Student.Management.System.Application.Ports.In;
using Student.Management.System.Application.Ports.Out;
using Student.Management.System.Domain.Entities;

namespace Student.Management.System.Application.Services
{
    public class SubjectService : ISubjectService
    {

        private readonly ISubjectRepository _subjectRepository;

        public SubjectService(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }
        public ICollection<StudentDetails> GetStudentsWithSubject(int id)
        {
            return _subjectRepository.GetStudentsWithSubject(id);
        }

        public ICollection<Subject> GetAllSubjects()
        {
            return _subjectRepository.GetAllSubjects();
        }
    }
}