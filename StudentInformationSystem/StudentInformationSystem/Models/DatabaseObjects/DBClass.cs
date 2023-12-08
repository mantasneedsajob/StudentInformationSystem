namespace StudentInformationSystem.Models;

public class DBClass : DBObjectBase
{
    public string Name { get; set; } = string.Empty;
    public Class CreateDTO()
    {
        return new Class() { Name = Name };
    }
}
