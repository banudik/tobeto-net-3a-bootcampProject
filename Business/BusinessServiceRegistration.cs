using Business.Abstracts;
using Business.Abstracts.Employee;
using Business.Abstracts.Instructor;
using Business.Abstracts.User;
using Business.Concretes;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Business;

public static class BusinessServiceRegistration
{
    public static IServiceCollection AddBusinessService(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserManager>();
        services.AddScoped<IInstructorService, InstructorManager>();
        services.AddScoped<IApplicantService, ApplicantManager>();
        services.AddScoped<IEmployeeService, EmployeeManager>();
        return services;

    }


}
