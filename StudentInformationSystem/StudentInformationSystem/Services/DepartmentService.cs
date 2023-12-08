using StudentInformationSystem.Interfaces;
using StudentInformationSystem.Models;
using StudentInformationSystem.Helpers;

namespace StudentInformationSystem.Services;

public class DepartmentService : IDepartmentService
{
    private readonly IDatabaseService _databaseService;
    public DepartmentService(IDatabaseService databaseService)
    {
        _databaseService = databaseService;
    }

    public bool CreateDepartment(string name)
    {
        return _databaseService.CreateNewDepartmentIfNonExistent(new Department { Name = name }) != null;
    }
    public bool AddClass(string name, string departmentName)
    {
        return _databaseService.CreateNewClassIfNonExistent(new Class { Name = name }, new Department { Name = departmentName }) != null;
    }

    //public bool CreateNewDepartmentAndAdd(string departmentName, string classes, string students)
    //{
    //    // TODO
    //    throw new NotImplementedException();
    //}

    public bool TransferStudent(string firstName, string lastName, string fromDepartment, string toDepartment)
    {
        Student s = new Student { FirstName = firstName, LastName = lastName };
        if (_databaseService.RemoveStudent(s))
        {
            // possible side-effect: if duplicate student exists in toDeparmentName, student is still deleted in fromDepartmentName
            // even if department is similar, the student is still removed, then inserted
            return _databaseService.CreateNewStudentIfNonExistent(new Student { FirstName = s.FirstName, LastName = s.LastName, DepartmentName = toDepartment }) != null;
        }
        return false;
    }

    public List<Class> GetAllClasses(string department)
    {
        List<DBClass> dbList = _databaseService.GetAllClasses(new Department { Name = department }).ToList();
        return ObjectConverter.ToDTOList(dbList);
    }

    public List<Student> GetAllStudents(string department)
    {
        List<DBStudent> dbList = _databaseService.GetAllStudents(new Department { Name = department }).ToList();
        return ObjectConverter.ToDTOList(dbList);
    }
}
