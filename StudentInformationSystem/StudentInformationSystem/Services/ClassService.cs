using StudentInformationSystem.Interfaces;
using StudentInformationSystem.Models;

namespace StudentInformationSystem.Services;

public class ClassService : IClassService
{
    private readonly IDatabaseService _databaseService;
    public ClassService(IDatabaseService databaseService)
    {
        _databaseService = databaseService;
    }

    public bool CreateNewClass(string name, string departmentName)
    {
        return _databaseService.CreateNewClassIfNonExistent(new Class { Name = name }, new Department { Name = departmentName }) != null;
    }
}
