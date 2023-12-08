using StudentInformationSystem.Models;

namespace StudentInformationSystem.Interfaces;

public interface IStudentService
{
    public bool AddStudent(string firstName, string lastName, string department);
    public List<Class> GetClassesForStudent(string firstName, string lastName);
}
