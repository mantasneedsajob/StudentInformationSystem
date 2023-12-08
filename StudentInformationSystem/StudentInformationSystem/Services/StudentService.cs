using StudentInformationSystem.Interfaces;
using StudentInformationSystem.Models;
using StudentInformationSystem.Helpers;

namespace StudentInformationSystem.Services;

public class StudentService : IStudentService
{
    private readonly IDatabaseService _databaseService;
    public StudentService(IDatabaseService databaseService)
    {
        _databaseService = databaseService;
    }
    public bool AddStudent(string firstName, string lastName, string department)
    {
        return _databaseService.CreateNewStudentIfNonExistent(new Student { FirstName = firstName, LastName = lastName, DepartmentName = department }) != null;
    }

    public List<Class> GetClassesForStudent(string firstName, string lastName)
    {
        List<DBClass> dbList = _databaseService.GetAllClasses(new Student { FirstName = firstName, LastName = lastName }).ToList();
        return ObjectConverter.ToDTOList(dbList);
    }
}
