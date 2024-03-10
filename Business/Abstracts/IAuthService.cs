using Core.Utilities.Results;
using Core.Utilities.Security.Dtos;
using Core.Utilities.Security.JWT;
using Core.Utilities.Security.Entities;



namespace Business.Abstracts;

public interface IAuthService
{
    Task<DataResult<AccessToken>> Login(UserForLoginDto userForLoginDto);
    Task<DataResult<AccessToken>> EmployeeRegister(EmployeeForRegisterDto employeeForRegisterDto);
    Task<DataResult<AccessToken>> InstructorRegister(InstructorForRegisterDto instructorForRegisterDto);
    Task<DataResult<AccessToken>> ApplicantRegister(ApplicantForRegisterDto applicantForRegisterDto);
    Task<DataResult<AccessToken>> CreateAccessToken(User user);
}
