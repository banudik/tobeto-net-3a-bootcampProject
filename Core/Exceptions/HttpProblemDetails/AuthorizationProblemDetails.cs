using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core.Exceptions.HttpProblemDetails;

public class AuthorizationProblemDetails:ProblemDetails
{
    public AuthorizationProblemDetails(string detail)
    {
        Title = "Authorization Error";
        Detail = detail;
        Status = StatusCodes.Status401Unauthorized;
        Type = "http://tobeto.com/probs/authorization";
    }
}
