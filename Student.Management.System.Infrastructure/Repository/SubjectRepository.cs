using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Student.Management.System.Application.Ports.Out;
using Student.Management.System.Domain.Entities;
using Student.Management.System.Infrastructure.Data;

namespace Student.Management.System.Infrastructure.Repository
{
    public class SubjectRepository : ISubjectRepository
    {

        private DataContext context;

        public SubjectRepository(DataContext context)
        {
            this.context = context;
        }

        public ICollection<Subject> GetAllSubjects()
        {
            return context.Subjects.ToList();
        }

        public ICollection<StudentDetails> GetStudentsWithSubject(int id)
        {
            ICollection<StudentDetails>? studentDetails = context.Subjects.Where(s => s.SubjectId == id)
            .Include("Students").Select(s => s.Students).First();
            return studentDetails ?? new List<StudentDetails>();
            // return context.Subjects.Where(s => s.SubjectId == id).Include("Students")
            // .Select(s => new StudentDetails{
            //     FirstName = s.FirstName,
            //     MiddleName = s.MiddleName, 
            //     LastName = s.LastName, 
            //     DateOfBirth = s.DateOfBirth,
            //     Id = s.Id,
            //     SubjectId = s.SubjectId,
            //     Subject = new Subject{Name = s.Subject.Name, SubjectId = s.Subject.SubjectId}
            // }).First;
        }
    }
}