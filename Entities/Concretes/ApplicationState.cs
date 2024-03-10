using Core.Entities;

namespace Entities.Concretes;

public class ApplicationState:BaseEntity<int>
{
    public string Name { get; set; }

    public ApplicationState()
    {
        
    }

    public ApplicationState(string name)
    {
        Name = name;
    }
}
