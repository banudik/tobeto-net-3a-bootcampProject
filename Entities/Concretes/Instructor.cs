using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes;

public class Instructor:User
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string CompanyName { get; set; }

    public Instructor()
    {
        
    }

    public Instructor(int id, string companyName)
    {
        Id = id;
        CompanyName = companyName;

    }
}
