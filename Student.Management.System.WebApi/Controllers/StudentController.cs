global using Student.Management.System.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Student.Management.System.Application.Ports.In;
using Student.Management.System.Application.Ports.Out;
using Student.Management.System.Domain.Entities.Dto;

namespace Student.Management.System.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class StudentController : Controller
    {
        private IStudentService _service;

        public StudentController(IStudentService service)
        {
            _service = service;
        }

        [HttpGet("GetAll")]
        public ActionResult GetAllStudents(){
            var students = _service.GetAllStudents();
            if(!students.Any())
                return NoContent();

            return Ok(students);
        }

        [HttpPost("Post")]
        public async Task<ActionResult> AddStudent(AddStudentDto studentDto){
            return Ok(await _service.AddStudent(studentDto));
        }

        [HttpDelete("DeleteSingle/{Id}")]
        public async Task<ActionResult> DeleteSingle(int Id){
            try{
                var result = await _service.DeleteSingle(Id);
                return Ok(result);
            }
            catch(Exception ex){
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("DeleteMultiple")]
        public async Task<ActionResult> DeleteMultiple([FromQuery] String Ids){
            
            return Ok(await _service.DeleteMultiple(Ids));
        }

        [HttpPut("Update")]
        public async Task<ActionResult> UpdateStudent(int Id, GetStudentDto Student){
            
            if (Id != Student.Id)  
            {  
                return BadRequest();  
            }  

            try{
                GetStudentDto result = await _service.UpdateStudent(Student);
                return Ok(result);
            }
            catch(Exception ex){
                return NotFound(ex.Message);
            }
            
        }
            
        
    }
}