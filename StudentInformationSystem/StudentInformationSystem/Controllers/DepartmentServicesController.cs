using Microsoft.AspNetCore.Mvc;
using StudentInformationSystem.Extensions;
using StudentInformationSystem.Interfaces;
using StudentInformationSystem.Models;

namespace StudentInformationSystem.Controllers;

[ApiController]
[Route("Department:[action]")]
public class DepartmentServicesController : ControllerBase
{
    private readonly IDepartmentService _departmentService;
    public DepartmentServicesController(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateNew(string name)
    {
        return this.ActionResultFromBool(_departmentService.CreateDepartment(name));
    }

    //[HttpPost]
    //public async Task<IActionResult> CreateNewAndAdd(string departmentName, string classes, string students)
    //{
    //    return this.ActionResultFromBool(_departmentService.CreateNewDepartmentAndAdd(departmentName, classes, students));
    //}

    [HttpPost]
    public async Task<IActionResult> AddClass(string name, string departmentName)
    {
        return this.ActionResultFromBool(_departmentService.AddClass(name, departmentName));
    }

    [HttpPost]
    public async Task<IActionResult> TransferStudent(string firstName, string lastName, string fromDepartment, string toDepartment)
    {
        return this.ActionResultFromBool(_departmentService.TransferStudent(firstName, lastName, fromDepartment, toDepartment));
    }

    [HttpGet]
    public async Task<IActionResult> GetStudents(string department)
    {
        return Ok(_departmentService.GetAllStudents(department));
    }

    [HttpGet]
    public async Task<IActionResult> GetClasses(string department)
    {
        return Ok(_departmentService.GetAllClasses(department));
    }
}
