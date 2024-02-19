using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes;

public class Employee:User
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Position { get; set; }

    public Employee()
    {
        
    }

    public Employee(int id, string position)
    {
        Id = id;
        Position = position;

        
    }
}
