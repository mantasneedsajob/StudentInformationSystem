using StudentInformationSystem.Models;

namespace StudentInformationSystem.Interfaces;

public interface IDepartmentService
{
    public bool CreateDepartment(string name);
    // public bool CreateNewDepartmentAndAdd(string departmentName, string classes, string students);
    public bool AddClass(string name, string departmentName);
    public bool TransferStudent(string firstName, string lastName, string fromDepartment, string toDepartment);
    public List<Student> GetAllStudents(string department);
    public List<Class> GetAllClasses(string department);
}
