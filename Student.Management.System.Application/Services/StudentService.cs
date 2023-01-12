using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Student.Management.System.Application.Ports.In;
using Student.Management.System.Application.Ports.Out;
using Student.Management.System.Domain.Entities;
using Student.Management.System.Domain.Entities.Dto;

namespace Student.Management.System.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }
        
        public List<StudentDetails> GetAllStudents()
        {
            // var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            var dbStudents = _studentRepository.GetStudents();
            return dbStudents.ToList();
           
        }
        public async Task<List<GetStudentDto>> AddStudent(AddStudentDto studentDto)
        {
            StudentDetails student = _mapper.Map<StudentDetails>(studentDto);

            var dbStudents = await _studentRepository.InsertStudent(student);
            return dbStudents.ToList();
        }

        
    }
}