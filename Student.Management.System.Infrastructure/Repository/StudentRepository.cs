using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dapper;
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
        private readonly DapperContext _dappercontext;
        public StudentRepository(DataContext context, IMapper mapper, DapperContext dapperContext)
        {
            this.context = context;
            _mapper = mapper;
            _dappercontext = dapperContext;
        }

        public IEnumerable<StudentDetails> GetStudents()
        {
            //return context.Students.Include("Subject").ToList();

            return context.Students.Select(s => new StudentDetails
            {
                FirstName = s.FirstName,
                MiddleName = s.MiddleName,
                LastName = s.LastName,
                DateOfBirth = s.DateOfBirth,
                Id = s.Id,
                SubjectId = s.SubjectId,
                Subject = new Subject { Name = s.Subject.Name, SubjectId = s.Subject.SubjectId }
            }).ToList();
        }

        public async Task<StudentDetails> InsertStudent(StudentDetails student)
        {

            try
            {
                context.Students.Add(student);
                await context.SaveChangesAsync();
                return student;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<GetStudentDto> DeleteSingle(int id)
        {
            try
            {
                var student = await context.Students.FirstOrDefaultAsync(c => c.Id == id);
                if (student is null)
                {
                    throw new Exception($"Student with Id {id} not found");
                }
                context.Students.Remove(student);
                await context.SaveChangesAsync();
                GetStudentDto resultStudent = _mapper.Map<GetStudentDto>(student);
                return resultStudent;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<GetStudentDto> UpdateStudent(GetStudentDto student)
        {

            try
            {

                StudentDetails finalStudent = _mapper.Map<StudentDetails>(student);
                var studentToUpdate = await context.Students.FirstOrDefaultAsync(c => c.Id == finalStudent.Id);
                if (studentToUpdate == null)
                {
                    throw new Exception($"Student with Id {finalStudent.Id} not found");
                }
                else
                {
                    context.Entry(studentToUpdate).State = EntityState.Detached;

                }

                context.Entry(finalStudent).State = EntityState.Modified;

                await context.SaveChangesAsync();
                return student;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<GetStudentDto>> GetStudentsWithDapper()
        {
            var query = "SELECT * FROM Students";
            using (var connection = _dappercontext.CreateConnection())
            {
                var students = await connection.QueryAsync<StudentDetails>(query);
                var studentDto = new List<GetStudentDto>();
                foreach (var student in students)
                {
                    studentDto.Add(_mapper.Map<GetStudentDto>(student));
                }
                return studentDto;
            }
        }
    }
}