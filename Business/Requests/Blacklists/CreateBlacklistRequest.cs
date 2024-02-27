using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Requests.Blacklists;

public class CreateBlacklistRequest
{
    public string Reason { get; set; }
    public DateTime Date { get; set; }
    public int ApplicantId { get; set; }
}
