using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Student.Management.System.Domain.Entities.Dto;

namespace Student.Management.System.WebApi
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<StudentDetails,GetStudentDto>();
            CreateMap<AddStudentDto , StudentDetails>();
            CreateMap<GetStudentDto,StudentDetails>();
            // CreateMap<UpdateCharacterDto, Character>();
        }
    }
}