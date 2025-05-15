using Xunit;
using Moq;
using StudentRestAPI.Controllers;
using StudentRestAPI.Models;
using StudentRestAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text;
using Microsoft.Extensions.Logging;

public class StudentControllerTests
{
    private readonly StudentsController _controller;
    private readonly Mock<IStudentRepository> _mockRepo;
    private readonly List<Student> _testStudents;
    private readonly Mock<ILogger<StudentsController>> _mockLogger;

    public StudentControllerTests()
    {
        _mockRepo = new Mock<IStudentRepository>();
        _mockLogger = new Mock<ILogger<StudentsController>>();

        _controller = new StudentsController(_mockRepo.Object, _mockLogger.Object);
        // Sample test students
        _testStudents = new List<Student>
        {
            new Student { Id = 1, FirstName = "John", LastName = "Smith", Address = "123 Main St", DateOfBirth = DateOnly.Parse("2010-01-01"), Email="jsmith@test.com", Grade = "5", Phone="123-345-7890" },
            new Student { Id = 2, FirstName = "Emma", LastName = "Johnson", Address = "987 Pineer Bld", DateOfBirth = DateOnly.Parse("2009-05-15"), Email="ejohnson@test.com", Grade = "K", Phone="111-222-3333"}
        };
    }

    private IList<ValidationResult> ValidateModel(object model)
    {
        var validationResults = new List<ValidationResult>();
        var ctx = new ValidationContext(model, null, null);
        Validator.TryValidateObject(model, ctx, validationResults, true);
        return validationResults;
    }

    [Fact]
    public void GetAllStudents_ReturnsOkResult_WithListOfStudents()
    {
        _mockRepo.Setup(repo => repo.GetAllStudents()).Returns(_testStudents);

        var result = _controller.GetAllStudents();

        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnStudents = Assert.IsType<List<Student>>(okResult.Value);
        Assert.Equal(2, returnStudents.Count);
    }

    [Fact]
    public void GetStudent_ExistingId_ReturnsStudent()
    {
        _mockRepo.Setup(repo => repo.GetStudent(1)).Returns(_testStudents[0]);

        var result = _controller.GetStudent(1);

        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(_testStudents[0], okResult.Value);
    }

    [Fact]
    public void GetStudent_NonExistingId_ReturnsNotFound()
    {
        _mockRepo.Setup(repo => repo.GetStudent(100)).Returns((Student)null);

        var result = _controller.GetStudent(99);

        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public void CreateStudent_ValidStudent_ReturnsNewStudent()
    {
        var newStudent = new Student
        {
            FirstName = "New",
            LastName = "Student",
            Grade = "5",
            Address = "789 Rd",
            DateOfBirth = new DateOnly(2012, 6, 15)
        };

        _mockRepo.Setup(repo => repo.InsertStudent(It.IsAny<Student>())).Returns(newStudent);

        var result = _controller.CreateStudent(newStudent);

        _mockRepo.Verify(repo => repo.InsertStudent(newStudent), Times.Once);
        var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
        Assert.Equal(newStudent, createdAtActionResult.Value);
    }

    [Fact]
    public void CreateStudent_MissingFirstName_ReturnsBadRequest()
    {
        var newStudent = new Student
        {
            //FirstName = "New",
            LastName = "Student",
            Grade = "5",
            Address = "789 Rd",
            DateOfBirth = new DateOnly(2012, 6, 15)
        };

        _mockRepo.Setup(repo => repo.InsertStudent(It.IsAny<Student>())).Returns(newStudent);

        var results = ValidateModel(newStudent);
        foreach (var result in results)
        {
            _controller.ModelState.AddModelError(result.MemberNames.First(), result.ErrorMessage);
        }

        var response = _controller.CreateStudent(newStudent);

        Assert.Equal(ModelValidationState.Invalid, _controller.ModelState["FirstName"].ValidationState);
        Assert.IsType<BadRequestObjectResult>(response);
    }

    [Fact]
    public void CreateStudent_MissingLastName_ReturnsBadRequest()
    {
        var newStudent = new Student
        {
            FirstName = "New",
            //LastName = "Student",
            Grade = "5",
            Address = "789 Rd",
            DateOfBirth = new DateOnly(2012, 6, 15)
        };

        _mockRepo.Setup(repo => repo.InsertStudent(It.IsAny<Student>())).Returns(newStudent);

        var results = ValidateModel(newStudent);
        foreach (var result in results)
        {
            _controller.ModelState.AddModelError(result.MemberNames.First(), result.ErrorMessage);
        }

        var response = _controller.CreateStudent(newStudent);

        Assert.Equal(ModelValidationState.Invalid, _controller.ModelState["LastName"].ValidationState);
        Assert.IsType<BadRequestObjectResult>(response);
    }

    [Fact]
    public void CreateStudent_MissingAddress_ReturnsBadRequest()
    {
        var newStudent = new Student
        {
            FirstName = "New", 
            LastName = "Student",
            Grade = "5",
            //Address = "789 Rd",
            DateOfBirth = new DateOnly(2012, 6, 15)
        };

        _mockRepo.Setup(repo => repo.InsertStudent(It.IsAny<Student>())).Returns(newStudent);

        var results = ValidateModel(newStudent);
        foreach (var result in results)
        {
            _controller.ModelState.AddModelError(result.MemberNames.First(), result.ErrorMessage);
        }

        var response = _controller.CreateStudent(newStudent);

        Assert.Equal(ModelValidationState.Invalid, _controller.ModelState["Address"].ValidationState);
        Assert.IsType<BadRequestObjectResult>(response);
    }

    [Fact]
    public void CreateStudent_MissingDateOfBirth_ReturnsBadRequest()
    {
        var newStudent = new Student
        {
            FirstName = "Test First Name",
            LastName = "Student",
            Grade = "5",
            Address = "789 Rd",
            //DateOfBirth = new DateOnly(2012, 6, 15)
        };

        _mockRepo.Setup(repo => repo.InsertStudent(It.IsAny<Student>())).Returns(newStudent);

        var results = ValidateModel(newStudent);
        foreach (var result in results)
        {
            _controller.ModelState.AddModelError(result.MemberNames.First(), result.ErrorMessage);
        }

        var response = _controller.CreateStudent(newStudent);

        Assert.Equal(ModelValidationState.Invalid, _controller.ModelState["DateOfBirth"].ValidationState);
        Assert.IsType<BadRequestObjectResult>(response);
    }

    [Fact]
    public void CreateStudent_MissingGrade_ReturnsBadRequest()
    {
        var newStudent = new Student
        {
            FirstName = "Test First Name",
            LastName = "Student",
            //Grade = "5",
            Address = "789 Rd",
            DateOfBirth = new DateOnly(2012, 6, 15)
        };

        _mockRepo.Setup(repo => repo.InsertStudent(It.IsAny<Student>())).Returns(newStudent);

        var results = ValidateModel(newStudent);
        foreach (var result in results)
        {
            _controller.ModelState.AddModelError(result.MemberNames.First(), result.ErrorMessage);
        }

        var response = _controller.CreateStudent(newStudent);

        Assert.Equal(ModelValidationState.Invalid, _controller.ModelState["Grade"].ValidationState);
        Assert.IsType<BadRequestObjectResult>(response);
    }

    [Fact]
    public void CreateStudent_WithFutureDateOfBirth_ReturnsBadRequest()
    {
        var futureStudent = new Student
        {
            FirstName = "John",
            LastName = "Doe",
            Address = "Address Test",
            DateOfBirth = DateOnly.FromDateTime(DateTime.Today.AddDays(1)),
            Grade = "12"
        };

        _mockRepo.Setup(repo => repo.InsertStudent(It.IsAny<Student>())).Returns(futureStudent);

        var results = ValidateModel(futureStudent);
        foreach (var result in results)
        {
            _controller.ModelState.AddModelError(result.MemberNames.First(), result.ErrorMessage);
        }

        var response = _controller.CreateStudent(futureStudent);

        Assert.Equal(ModelValidationState.Invalid, _controller.ModelState["DateOfBirth"].ValidationState);
        Assert.IsType<BadRequestObjectResult>(response);
    }


    [Fact]
    public void CreateStudent_WithInvalidPhone_ReturnsBadRequest()
    {
        var futureStudent = new Student
        {
            FirstName = "John",
            LastName = "Doe",
            Address = "Address Test",
            DateOfBirth = DateOnly.FromDateTime(DateTime.Today.AddDays(-10)),
            Grade = "12",
            Phone = "1234PhoneTest"
        };

        var results = ValidateModel(futureStudent);
        foreach (var result in results)
        {
            _controller.ModelState.AddModelError(result.MemberNames.First(), result.ErrorMessage);
        }

        var response = _controller.CreateStudent(futureStudent);

        Assert.Equal(ModelValidationState.Invalid, _controller.ModelState["Phone"].ValidationState);
        Assert.IsType<BadRequestObjectResult>(response);
    }

    [Fact]
    public void CreateStudent_WithInvalidEmail_ReturnsBadRequest()
    {
        var futureStudent = new Student
        {
            FirstName = "John",
            LastName = "Doe",
            Address = "Address Test",
            DateOfBirth = DateOnly.FromDateTime(DateTime.Today.AddDays(-10)),
            Grade = "12",
            Email = "testemail"
        };

        var results = ValidateModel(futureStudent);
        foreach (var result in results)
        {
            _controller.ModelState.AddModelError(result.MemberNames.First(), result.ErrorMessage);
        }

        var response = _controller.CreateStudent(futureStudent);

        Assert.Equal(ModelValidationState.Invalid, _controller.ModelState["Email"].ValidationState);
        Assert.IsType<BadRequestObjectResult>(response);
    }

    [Fact]
    public void UpdateStudent_ExistingId_ReturnsNoCentent()
    {
        var updatedStudent = new Student
        {
            Id = 1,
            FirstName = "Updated",
            LastName = "Student",
            Grade = "7",
            Address = "100 Main",
            DateOfBirth = new DateOnly(2010, 10, 10)
        };
        _mockRepo.Setup(repo => repo.GetStudent(updatedStudent.Id)).Returns(updatedStudent);

        var result = _controller.UpdateStudent(1, updatedStudent);

        _mockRepo.Verify(repo => repo.UpdateStudent(1, updatedStudent), Times.Once);
        var okResult = Assert.IsType<NoContentResult>(result);
        Assert.IsType<NoContentResult>(okResult);
    }

    [Fact]
    public void UpdateStudent_NonExistingId_ReturnsNotFound()
    {
        var updatedStudent = _testStudents[0];
        updatedStudent.Id = 100;

        var result = _controller.UpdateStudent(100, updatedStudent);

        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public void UpdateStudent_InvalidGrade_ReturnsBadRequest()
    {
        var updatedStudent = _testStudents[0];
        updatedStudent.Grade = "99";

        var results = ValidateModel(updatedStudent);
        foreach (var validateResult in results)
        {
            _controller.ModelState.AddModelError(validateResult.MemberNames.First(), validateResult.ErrorMessage);
        }

        var result = _controller.UpdateStudent(1, updatedStudent);

        Assert.Equal(ModelValidationState.Invalid, _controller.ModelState["Grade"].ValidationState);
        Assert.IsType<BadRequestObjectResult>(result);
    }

    [Fact]
    public void UpdateStudent_FirstNameExceedLength_ReturnsBadRequest()
    {
        var updatedStudent = _testStudents[0];
        updatedStudent.FirstName = new StringBuilder().Insert(0, updatedStudent.FirstName, 20).ToString();

        var results = ValidateModel(updatedStudent);
        foreach (var validateResult in results)
        {
            _controller.ModelState.AddModelError(validateResult.MemberNames.First(), validateResult.ErrorMessage);
        }

        var result = _controller.UpdateStudent(1, updatedStudent);

        Assert.Equal(ModelValidationState.Invalid, _controller.ModelState["FirstName"].ValidationState);
        Assert.IsType<BadRequestObjectResult>(result);
    }

    [Fact]
    public void UpdateStudent_LastNameExceedLength_ReturnsBadRequest()
    {
        var updatedStudent = _testStudents[0];
        updatedStudent.LastName = new StringBuilder().Insert(0, updatedStudent.LastName, 20).ToString();

        var results = ValidateModel(updatedStudent);
        foreach (var validateResult in results)
        {
            _controller.ModelState.AddModelError(validateResult.MemberNames.First(), validateResult.ErrorMessage);
        }

        var result = _controller.UpdateStudent(1, updatedStudent);

        Assert.Equal(ModelValidationState.Invalid, _controller.ModelState["LastName"].ValidationState);
        Assert.IsType<BadRequestObjectResult>(result);
    }

    [Fact]
    public void UpdateStudent_AddressExceedLength_ReturnsBadRequest()
    {
        var updatedStudent = _testStudents[0];
        updatedStudent.Address = new StringBuilder().Insert(0, updatedStudent.Address, 50).ToString();

        var results = ValidateModel(updatedStudent);
        foreach (var validateResult in results)
        {
            _controller.ModelState.AddModelError(validateResult.MemberNames.First(), validateResult.ErrorMessage);
        }

        var result = _controller.UpdateStudent(1, updatedStudent);

        Assert.Equal(ModelValidationState.Invalid, _controller.ModelState["Address"].ValidationState);
        Assert.IsType<BadRequestObjectResult>(result);
    }

    [Fact]
    public void DeleteStudent_ExistingId_ReturnsNoContent()
    {
        var student = _testStudents[1];
        _mockRepo.Setup(repo => repo.GetStudent(student.Id)).Returns(student);

        var result = _controller.DeleteStudent(student.Id);

        _mockRepo.Verify(repo => repo.DeleteStudent(student.Id), Times.Once);
        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public void DeleteStudent_NonExistingId_ReturnsNotFound()
    {
        _mockRepo.Setup(repo => repo.GetStudent(100)).Returns((Student)null);

        var result = _controller.DeleteStudent(100);

        Assert.IsType<NotFoundResult>(result);
    }
}
