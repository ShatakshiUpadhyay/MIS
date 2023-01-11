global using Student.Management.System.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Student.Management.System.Application.Ports.In;
using Student.Management.System.Application.Ports.Out;

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

        [HttpGet]
        public ActionResult GetAllStudents(){
            
            return Ok(_service.GetAllStudents());
        }
    }
}