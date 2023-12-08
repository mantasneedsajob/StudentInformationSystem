namespace StudentInformationSystem.Models;

public class DBStudent : DBObjectBase
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int DepartmentId { get; set; } = 0;

    public Student CreateDTO()
    {
        return new Student { FirstName = FirstName, LastName = LastName };
    }
}
