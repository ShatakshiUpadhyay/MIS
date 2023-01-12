using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Student.Management.System.Application.Ports.In;
using Student.Management.System.Application.Ports.Out;
using Student.Management.System.Domain.Entities;

namespace Student.Management.System.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        
        public List<StudentDetails> GetAllStudents()
        {
            // var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            var dbStudents = _studentRepository.GetStudents();
            return dbStudents.ToList();
           
        }
        public async Task<List<StudentDetails>> AddStudent(StudentDetails student)
        {
            var dbStudents = await _studentRepository.InsertStudent(student);
            return dbStudents.ToList();
        }
    }
}