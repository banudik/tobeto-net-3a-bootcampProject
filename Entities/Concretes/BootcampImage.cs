using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

