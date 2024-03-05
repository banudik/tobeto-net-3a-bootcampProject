using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes;

public class Bootcamp: BaseEntity<int>
{
    public string Name { get; set; }
    public int InstructorId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int BootcampStateId { get; set; }
    public virtual Instructor? Instructor { get; set; }
    public virtual ICollection<Application> Applications { get; set; }
    public virtual BootcampState BootcampState { get; set; }
    public virtual ICollection<BootcampImage> BootcampImages { get; set; }

    public Bootcamp()
    {
        BootcampImages = new HashSet<BootcampImage>();
        Applications = new HashSet<Application>();
    }

    public Bootcamp(string name, int ınstructorId, DateTime startDate, DateTime endDate, int bootcampStateId, Instructor? ınstructor, ICollection<Application> applications, BootcampState bootcampState, ICollection<BootcampImage> bootcampImages)
    {
        Name = name;
        InstructorId = ınstructorId;
        StartDate = startDate;
        EndDate = endDate;
        BootcampStateId = bootcampStateId;
        Instructor = ınstructor;
        Applications = applications;
        BootcampState = bootcampState;
        BootcampImages = bootcampImages;
    }
}
