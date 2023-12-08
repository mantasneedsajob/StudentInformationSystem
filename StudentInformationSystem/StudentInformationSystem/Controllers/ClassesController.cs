using Microsoft.AspNetCore.Mvc;
using StudentInformationSystem.Interfaces;
using StudentInformationSystem.Extensions;

namespace StudentInformationSystem.Controllers;

[ApiController]
[Route("Class:[action]")]
public class ClassesController : ControllerBase
{
    private readonly IClassService _classService;
    public ClassesController(IClassService classService)
    {
        _classService = classService;
    }

    [HttpPost]
    public async Task<IActionResult> AddNew(string className, string departmentName)
    {
        return this.ActionResultFromBool(_classService.CreateNewClass(className, departmentName));
    }
}
