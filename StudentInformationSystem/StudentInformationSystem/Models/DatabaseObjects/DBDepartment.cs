namespace StudentInformationSystem.Models;

public class DBDepartment : DBObjectBase
{
    public string Name { get; set; } = string.Empty;

    public Department CreateDTO()
    {
        return new Department() { Name = Name };
    }
}
