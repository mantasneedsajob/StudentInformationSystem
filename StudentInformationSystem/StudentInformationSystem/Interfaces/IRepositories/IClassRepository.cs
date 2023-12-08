using StudentInformationSystem.Models;

namespace StudentInformationSystem.Interfaces;

public interface IClassRepository
{
    public DBClass? CreateClass(Class c);
    public bool RemoveClass(Class c);
    public DBClass? FindClass(string name);
    public DBClass? FindClass(Class c);
    public DBClass? FindClass(int id);
}
