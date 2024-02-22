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
}
