using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes;

public class Employee:User
{
    public string Position { get; set; }

    public Employee()
    {
        
    }

    public Employee(string position)
    {
        Position = position;

        
    }
}
