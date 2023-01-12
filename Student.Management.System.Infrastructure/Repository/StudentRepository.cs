using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Student.Management.System.Application.Ports.Out;
using Student.Management.System.Domain.Entities;
using Student.Management.System.Domain.Entities.Dto;
using Student.Management.System.Infrastructure.Data;

namespace Student.Management.System.Infrastructure.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private DataContext context;
         private readonly IMapper _mapper;
        public StudentRepository(DataContext context , IMapper mapper)
        {
            this.context = context;
            mapper = _mapper;
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

        public async Task<List<GetStudentDto>> InsertStudent(StudentDetails student)
        {
            var newstudents = new List<GetStudentDto>();
            context.Students.Add(student);
            await context.SaveChangesAsync();
            newstudents = await context.Students.Select(s=> _mapper.Map<GetStudentDto>(s)).ToListAsync();

            return newstudents;
        }
    }
}