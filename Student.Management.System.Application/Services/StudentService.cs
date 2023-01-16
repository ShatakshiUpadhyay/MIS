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
        public async Task<GetStudentDto> AddStudent(AddStudentDto studentDto)
        {
            StudentDetails student = _mapper.Map<StudentDetails>(studentDto);

            var dbStudents = await _studentRepository.InsertStudent(student);
            var finalStudent = _mapper.Map<GetStudentDto>(dbStudents);
            return finalStudent;
        }

        public async Task<GetStudentDto> DeleteSingle(int id)
        {
            GetStudentDto deletedStudent = await _studentRepository.DeleteSingle(id);
            return deletedStudent;
        }

        public async Task<List<GetStudentDto>> DeleteMultiple(string Ids)
        {
            List<String> deleteStudentsIds = Ids.Split(",").ToList();
            List<GetStudentDto> deletedStudents = new List<GetStudentDto>();

            foreach (string studentId in deleteStudentsIds)
            {
                deletedStudents.Add( await DeleteSingle(int.Parse(studentId))); 
            }

            return deletedStudents;
        
        }

        public async Task<GetStudentDto> UpdateStudent(GetStudentDto student)
        {
           
            return await _studentRepository.UpdateStudent(student);
        
        }
    }
}