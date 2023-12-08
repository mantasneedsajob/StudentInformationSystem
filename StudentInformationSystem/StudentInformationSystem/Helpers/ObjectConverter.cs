using StudentInformationSystem.Models;

namespace StudentInformationSystem.Helpers;

public static class ObjectConverter
{
    // TODO: look for ways to make these methods generic so overloads would not be necessary
    public static Class ToDTO(DBClass c)
    {
        return c.CreateDTO();
    }

    public static Student ToDTO(DBStudent s)
    {
        return s.CreateDTO();
    }

    public static Department ToDTO(DBDepartment d)
    {
        return d.CreateDTO();
    }

    public static List<Class> ToDTOList(List<DBClass> list)
    {
        List<Class> result = new List<Class>(); // TODO: consider initializing with default capacity
        foreach (DBClass dbClass in list)
        {
            // TODO: is there a way to make this method generic and call CreateDTO on any object passed here?
            result.Add(dbClass.CreateDTO());
        }
        return result;
    }

    public static List<Student> ToDTOList(List<DBStudent> list)
    {
        List<Student> result = new List<Student>(); // TODO: consider initializing with default capacity
        foreach (DBStudent item in list)
        {
            result.Add(item.CreateDTO());
        }
        return result;
    }

    public static List<Department> ToDTOList(List<DBDepartment> list)
    {
        List<Department> result = new List<Department>(); // TODO: consider initializing with default capacity
        foreach (DBDepartment item in list)
        {
            result.Add(item.CreateDTO());
        }
        return result;
    }
}
