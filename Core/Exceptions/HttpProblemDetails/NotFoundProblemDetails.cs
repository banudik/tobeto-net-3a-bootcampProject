using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Exceptions.HttpProblemDetails;

public class NotFoundProblemDetails:ProblemDetails
{
    public NotFoundProblemDetails(string detail)
    {
        Title = "Not found";
        Detail = detail;
        Status = StatusCodes.Status404NotFound;
        Type = "http://tobeto.com/probs/notfound";
    }
}
