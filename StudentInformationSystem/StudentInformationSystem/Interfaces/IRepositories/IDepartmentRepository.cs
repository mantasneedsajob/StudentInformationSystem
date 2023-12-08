using StudentInformationSystem.Models;

namespace StudentInformationSystem.Interfaces;

public interface IDepartmentRepository
{
    public DBDepartment? CreateDepartment(Department d);
    public bool RemoveDepartment(Department d);
    public DBDepartment? FindDepartment(string name);
    public DBDepartment? FindDepartment(Department d);
    public DBDepartment? FindDepartment(int id);
}
