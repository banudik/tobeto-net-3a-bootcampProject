using Core.Entities;

namespace Entities.Concretes;

public class Blacklist:BaseEntity<int>
{
    public string Reason { get; set; }
    public DateTime Date { get; set; }
    public int ApplicantId { get; set; }

    public Applicant Applicant { get; set; }

    public Blacklist()
    {
        
    }

    public Blacklist(string reason, DateTime date, int applicantId, Applicant applicant)
    {
        Reason = reason;
        Date = date;
        ApplicantId = applicantId;
        Applicant = applicant;
    }
}
