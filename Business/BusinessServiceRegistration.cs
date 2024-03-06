using Core.CrossCuttingConcerns.Rules;
using Core.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Business;

public static class BusinessServiceRegistration
{
    public static IServiceCollection AddBusinessService(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddSubClassesOfType(Assembly.GetExecutingAssembly(), typeof(BaseBusinessRules));

        //services.AddScoped<IUserService, UserManager>();
        //services.AddScoped<IInstructorService, InstructorManager>();
        //services.AddScoped<IApplicantService, ApplicantManager>();
        //services.AddScoped<IEmployeeService, EmployeeManager>();
        //services.AddScoped<IApplicationService, ApplicationManager>();
        //services.AddScoped<IApplicationStateService, ApplicationStateManager>();
        //services.AddScoped<IBootcampService, BootcampManager>();
        //services.AddScoped<IBootcampStateService, BootcampStateManager>();
        //services.AddScoped<IBlacklistService, BlacklistManager>();

        services.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).Where(x => x.ServiceType.Name.EndsWith("Manager"));

        return services;

    }


}
