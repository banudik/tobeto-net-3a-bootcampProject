using Core.Entities;

namespace Entities.Concretes;

public class BootcampImage:BaseEntity<int>
{
    public int BootcampId { get; set; }
    public string ImagePath { get; set; }
    public virtual Bootcamp Bootcamp { get; set; }

    public BootcampImage()
    {
        
    }

    public BootcampImage(int bootcampId, string ımagePath, Bootcamp bootcamp)
    {
        BootcampId = bootcampId;
        ImagePath = ımagePath;
        Bootcamp = bootcamp;
    }
}

