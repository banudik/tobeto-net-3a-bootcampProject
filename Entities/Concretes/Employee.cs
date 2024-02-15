using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes;

public class Employee:User
{
    public int UserId { get; set; }
    public string Position { get; set; }

    public Employee()
    {
        
    }

    public Employee(int userId, string position, string userName, string firstName, string lastName, DateTime dateOfBirth, string nationalIdentity, string eMail, string password)
    {
        UserId = userId;
        Position = position;
        UserName = userName;
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        NationalIdentity = nationalIdentity;
        Email = eMail;
        Password = password;
        
    }
}
