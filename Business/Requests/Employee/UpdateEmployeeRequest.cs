﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Requests.Employee;

public class UpdateEmployeeRequest
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Position { get; set; }
}
