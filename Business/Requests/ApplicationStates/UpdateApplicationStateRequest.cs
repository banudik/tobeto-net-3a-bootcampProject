﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Requests.ApplicationStates;


public class UpdateApplicationStateRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
}
