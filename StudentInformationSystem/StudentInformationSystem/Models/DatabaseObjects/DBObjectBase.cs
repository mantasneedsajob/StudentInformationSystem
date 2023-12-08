using System.Xml.Linq;

namespace StudentInformationSystem.Models;

public class DBObjectBase
{
    public int Id { get; set; } = 0;
    public DateTime Created { get; set; } = DateTime.Now;
}
