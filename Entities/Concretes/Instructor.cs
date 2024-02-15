using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes;

public class Instructor:User
{
    public int UserId { get; set; }
    public string CompanyName { get; set; }

    public Instructor()
    {
        
    }

    public Instructor(int userId, string companyName, string userName, string firstName, string lastName, DateTime dateOfBirth, string nationalIdentity, string eMail, string password)
    {
        UserId = userId;
        CompanyName = companyName;
        UserName = userName;
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        NationalIdentity = nationalIdentity;
        Email = eMail;
        Password = password;

        

    }
}
