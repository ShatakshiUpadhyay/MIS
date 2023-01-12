using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Student.Management.System.WebApi.Controllers;
using Student.Management.System.Application.Ports.In;
using Student.Management.System.Domain.Entities;
using Microsoft.AspNetCore.Mvc;


namespace Student.Management.System.Tests
{
    public class StudentControllerTest
    {
        private readonly Mock<IStudentService> _mockService;
        private readonly StudentController _controller;

        public StudentControllerTest()
        {
            _mockService = new Mock<IStudentService>();
            _controller = new StudentController(_mockService.Object);
        }
        
        [Fact]
        public void ShouldReturnListOfAllStudentsWhenCalled()
        {
             _mockService.Setup(service => service.GetAllStudents())
                .Returns(new List<StudentDetails>() { new StudentDetails(), new StudentDetails() });

            var result = _controller.GetAllStudents();

            var okResult = Assert.IsType<OkObjectResult>(result);

            var students = Assert.IsType<List<StudentDetails>>(okResult.Value);
            Assert.Equal(2, students.Count);
        }
    }
}