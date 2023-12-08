using StudentInformationSystem.Models;

namespace StudentInformationSystem.Interfaces;

public interface IStudentRepository
{
    public DBStudent? CreateStudent(DBStudent s);
    public bool RemoveStudent(Student s);
    public DBStudent? FindStudent(Student s);
    public DBStudent? FindStudent(int id);
}
