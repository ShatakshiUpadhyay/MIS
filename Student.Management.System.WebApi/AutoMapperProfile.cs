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
            CreateMap<StudentDetails,GetStudentDto>().ReverseMap();
            CreateMap<AddStudentDto , StudentDetails>().ReverseMap();
            CreateMap<GetStudentDto,StudentDetails>();
            CreateMap<GetStudentDto,AddStudentDto>().ReverseMap();
            // CreateMap<UpdateCharacterDto, Character>();
        }
    }
}