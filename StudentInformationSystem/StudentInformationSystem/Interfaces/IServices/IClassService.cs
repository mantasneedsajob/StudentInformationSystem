using StudentInformationSystem.Models;

namespace StudentInformationSystem.Interfaces;

public interface IClassService
{
    public bool CreateNewClass(string name, string departmentName);
}
