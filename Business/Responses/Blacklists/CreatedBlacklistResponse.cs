using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Responses.Blacklists;

public class CreatedBlacklistResponse
{
    public string Reason { get; set; }
    public DateTime Date { get; set; }
    public int ApplicantId { get; set; }
}
