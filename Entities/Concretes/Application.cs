﻿using Core.Entities;

namespace Entities.Concretes;

public class Application:BaseEntity<int>
{
    public int ApplicantId { get; set; }
    public int BootcampId { get; set; }
    public int ApplicationStateId { get; set; }

    public virtual Applicant? Applicant { get; set; }
    public virtual Bootcamp? Bootcamp { get; set; }
    public virtual ApplicationState? ApplicationState { get; set; }

    public Application()
    {
        
    }

    public Application(int applicantId, int bootcampId, int applicationStateId, Applicant? applicant, Bootcamp? bootcamp, ApplicationState? applicationState)
    {
        ApplicantId = applicantId;
        BootcampId = bootcampId;
        ApplicationStateId = applicationStateId;
        Applicant = applicant;
        Bootcamp = bootcamp;
        ApplicationState = applicationState;
    }
}
