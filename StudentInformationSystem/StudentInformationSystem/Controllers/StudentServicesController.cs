using Microsoft.AspNetCore.Mvc;
using StudentInformationSystem.Extensions;
using StudentInformationSystem.Interfaces;
using StudentInformationSystem.Models;

namespace StudentInformationSystem.Controllers;

[ApiController]
[Route("Student:[action]")]
public class StudentServicesController : ControllerBase
{
    private readonly IStudentService _studentService;
    public StudentServicesController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpPost]
    public async Task<IActionResult> AddNew(string firstName, string lastName, string department)
    {
        return this.ActionResultFromBool(_studentService.AddStudent(firstName, lastName, department));
    }

    [HttpGet]
    public async Task<IActionResult> GetClasses(string firstName, string lastName)
    {
        return Ok(_studentService.GetClassesForStudent(firstName, lastName));
    }
}
