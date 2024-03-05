using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Responses.Applications;

public class GetAllApplicationResponse
{
    public int Id { get; set; }
    public int ApplicantId { get; set; }
    public string ApplicantFirstName { get; set; }
    public string ApplicantLastName { get; set; }
    public DateTime ApplicantDateOfBirth { get; set; }
    public string ApplicantNationalIdentity { get; set; }
    public string BootcampName { get; set; }
    public string ApplicationStateName { get; set; }
}
