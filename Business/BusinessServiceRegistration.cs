using Business.Abstracts;
using Business.Abstracts.Applications;
using Business.Abstracts.ApplicationStates;
using Business.Abstracts.Blacklists;
using Business.Abstracts.Bootcamps;
using Business.Abstracts.BootcampStates;
using Business.Abstracts.Employee;
using Business.Abstracts.Instructor;
using Business.Abstracts.User;
using Business.Concretes;
using Business.Concretes.Applications;
using Business.Concretes.ApplicationStates;
using Business.Concretes.Blacklists;
using Business.Concretes.Bootcamps;
using Business.Concretes.BootcampStates;
using Entities.Concretes;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Business;

public static class BusinessServiceRegistration
{
    public static IServiceCollection AddBusinessService(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddScoped<IUserService, UserManager>();
        services.AddScoped<IInstructorService, InstructorManager>();
        services.AddScoped<IApplicantService, ApplicantManager>();
        services.AddScoped<IEmployeeService, EmployeeManager>();
        services.AddScoped<IApplicationService, ApplicationManager>();
        services.AddScoped<IApplicationStateService, ApplicationStateManager>();
        services.AddScoped<IBootcampService, BootcampManager>();
        services.AddScoped<IBootcampStateService, BootcampStateManager>();
        services.AddScoped<IBlacklistService, BlacklistManager>();
        return services;

    }


}
