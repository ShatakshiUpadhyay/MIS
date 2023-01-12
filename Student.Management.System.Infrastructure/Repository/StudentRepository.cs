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
    public class StudentRepository : IStudentRepository
    {
        private DataContext context;

        public StudentRepository(DataContext context)
        {
            this.context = context;
        }

        public IEnumerable<StudentDetails> GetStudents()
        {
            //return context.Students.Include("Subject").ToList();

            return context.Students.Select(s => new StudentDetails{
                FirstName = s.FirstName,
                MiddleName = s.MiddleName, 
                LastName = s.LastName, 
                DateOfBirth = s.DateOfBirth,
                Id = s.Id,
                SubjectId = s.SubjectId,
                Subject = new Subject{Name = s.Subject.Name, SubjectId = s.Subject.SubjectId}
            }).ToList();
        }

        public async Task<IEnumerable<StudentDetails>> InsertStudent(StudentDetails student)
        {
            context.Students.Add(student);
            await context.SaveChangesAsync();
            return context.Students.ToList();
        }
    }
}