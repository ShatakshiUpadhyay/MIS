using Moq;
using Student.Management.System.WebApi.Controllers;
using Student.Management.System.Application.Ports.In;
using Student.Management.System.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Student.Management.System.Domain.Entities.Dto;

namespace Student.Management.System.Tests
{
    public class StudentControllerTest
    {
        private readonly Mock<IStudentService> _mockService;
        private readonly StudentController _controller;

        public StudentControllerTest( )
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

        [Fact]
        public void ShouldAddNewStudentWhenCalled()
        {
            AddStudentDto studentDto=new AddStudentDto();
            _mockService.Setup(r => r.AddStudent(It.IsAny<AddStudentDto>())).Callback<AddStudentDto>(x => studentDto = x);
            var studentTest = new AddStudentDto{
                FirstName = "Test Name",
                MiddleName="Test Name",
                LastName="Test Name",
                DateOfBirth= new DateTime(2000,10,10),
                SubjectId = 3
            };
            ;
            Task<ActionResult> task = _controller.AddStudent(studentTest);
            _mockService.Verify(x => x.AddStudent(It.IsAny<AddStudentDto>()), Times.Once);

            Assert.Equal(studentDto.FirstName, studentTest.FirstName);
            Assert.Equal(studentDto.MiddleName, studentTest.MiddleName);
            Assert.Equal(studentDto.LastName, studentTest.LastName);
        }

        [Fact]
        public void ShouldDeleteStudentWhenIdIsGiven(){
            var id = 1;
            _mockService.Setup(s => s.DeleteSingle(id)).ReturnsAsync(new GetStudentDto());

            Task<ActionResult> task = _controller.DeleteSingle(id);

            _mockService.Verify(s => s.DeleteSingle(id), Times.Once);
        }

        [Fact]
        public void ShouldDeleteMultipleStudentWhenIdsAreGiven(){
            String ids = "1,2,3";
            _mockService.Setup(s => s.DeleteMultiple(ids)).ReturnsAsync(new List<GetStudentDto> {new GetStudentDto(), new GetStudentDto(), new GetStudentDto()});

            Task<ActionResult> task = _controller.DeleteMultiple(ids);

            _mockService.Verify(s => s.DeleteMultiple(ids), Times.Once);
        }
    }
}