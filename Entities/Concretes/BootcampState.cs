using Core.Entities;

namespace Entities.Concretes;

public class BootcampState: BaseEntity<int>
{
    public string Name { get; set; }

    public BootcampState()
    {
        
    }

    public BootcampState(string name)
    {
        Name = name;
    }
}
