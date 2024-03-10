using Core.Utilities.Security.Entities;

namespace Entities.Concretes;

public class Applicant:User
{
    public string About { get; set; }
    public Blacklist Blacklist { get; set; }
    public ICollection<Application> Applications { get; set; }

    public Applicant()
    {

    }

    public Applicant(string about)
    {
        About = about;

    }
}
