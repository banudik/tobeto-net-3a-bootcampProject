using Core.Utilities.Security.Entities;

namespace Entities.Concretes;

public class Employee:User
{
    public string Position { get; set; }

    public Employee()
    {
        
    }

    public Employee(string position)
    {
        Position = position;

        
    }
}
