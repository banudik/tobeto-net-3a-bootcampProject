using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Logging;

public class LogDetail
{
    public string MethodName { get; set; }
    public string User { get; set; }
    public List<LogParameter> LogParameters { get; set; }

    public LogDetail()
    {
    }

    public LogDetail(string methodName, string user, List<LogParameter> logParameters) : this()
    {
        MethodName = methodName;
        User = user;
        LogParameters = logParameters;
    }
}
