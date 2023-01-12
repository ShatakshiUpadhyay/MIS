using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Student.Management.System.Application.Ports.In;

namespace Student.Management.System.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : Controller
    {
        private ISubjectService _service;

        public SubjectController(ISubjectService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public ActionResult GetStudentsWithSubject(int id){
            
            return Ok( _service.GetStudentsWithSubject(id));
        }

    }
}