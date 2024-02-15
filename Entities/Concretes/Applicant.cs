using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes;

public class Applicant:User
{
    public int UserId { get; set; }
    public string About { get; set; }

    public Applicant()
    {
        
    }

    public Applicant(int userId, string about, string userName, string firstName, string lastName, DateTime dateOfBirth, string nationalIdentity, string eMail, string password)
    {
        UserId = userId;
        About = about;
        UserName = userName;
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        NationalIdentity = nationalIdentity;
        Email = eMail;
        Password = password;

    }
}
