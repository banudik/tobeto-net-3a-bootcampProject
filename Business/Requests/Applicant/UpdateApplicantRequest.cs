using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Requests.Applicant;

public class UpdateApplicantRequest
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string About { get; set; }

}
