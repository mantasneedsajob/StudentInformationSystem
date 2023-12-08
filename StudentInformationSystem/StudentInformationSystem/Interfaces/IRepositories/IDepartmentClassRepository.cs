using StudentInformationSystem.Models;

namespace StudentInformationSystem.Interfaces;

public interface IDepartmentClassRepository
{
    public (int, int)? CreatePair(DBDepartment d, DBClass c);
    public (int, int)? FindPair(DBDepartment d, DBClass c);
    public bool RemovePair(DBDepartment d, DBClass c);
}
