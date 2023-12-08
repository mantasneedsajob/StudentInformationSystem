using StudentInformationSystem.Interfaces;
using StudentInformationSystem.Models;

namespace StudentInformationSystem.Services;

public class DatabaseService : IDatabaseService
{
    private readonly IClassRepository _classRepo;
    private readonly IDepartmentRepository _departmentRepo;
    private readonly IStudentRepository _studentRepo;
    private readonly IDepartmentClassRepository _departmentClassRepo;

    public DatabaseService(IClassRepository classRepo, IDepartmentRepository departmentRepo, IStudentRepository studentRepo, IDepartmentClassRepository departmentClassRepo)
    {
        _classRepo = classRepo;
        _departmentRepo = departmentRepo;
        _studentRepo = studentRepo;
        _departmentClassRepo = departmentClassRepo;
    }

    public DBClass? CreateNewClassIfNonExistent(Class c, Department d)
    {
        DBDepartment? dept = _departmentRepo.FindDepartment(d.Name);
        if (dept != null)
        {
            DBClass? cl = _classRepo.CreateClass(c);
            if (cl != null)
            {
                // TODO create pair in conjuction table
                //_departmentClassRepo.CreatePair()
            }

        }
        return null;
    }

    public DBDepartment? CreateNewDepartmentIfNonExistent(Department d)
    {
        DBDepartment? dept = _departmentRepo.FindDepartment(d.Name);
        if (dept == null)
        {
            return _departmentRepo.CreateDepartment(d);
        }
        return null; // department not created
    }

    public DBStudent? CreateNewStudentIfNonExistent(Student s)
    {
        DBDepartment? dept = _departmentRepo.FindDepartment(s.DepartmentName);
        if (dept != null && _studentRepo.FindStudent(s) == null)
        {
            DBStudent st = new DBStudent { FirstName = s.FirstName, LastName = s.LastName, DepartmentId = dept.Id };
            _studentRepo.CreateStudent(st);
        }
        return null;
    }

    public bool RemoveStudent(Student s)
    {
        return _studentRepo.RemoveStudent(s);
    }

    public DBClass? GetClass(int id)
    {
        return _classRepo.FindClass(id);
    }

    public DBDepartment? GetDepartment(int id)
    {
        return _departmentRepo.FindDepartment(id);
    }

    public DBStudent? GetStudent(int id)
    {
        return _studentRepo.FindStudent(id);
    }

    public IEnumerable<DBClass> GetAllClasses(Department d)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<DBClass> GetAllClasses(Student s)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<DBStudent> GetAllStudents(Department d)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<DBDepartment> GetAllStudents(Class c)
    {
        throw new NotImplementedException();
    }
}
