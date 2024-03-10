using Business.Abstracts;
using Business.Rules;
using Core.Utilities.Results;
using Core.Utilities.Security.Dtos;
using Core.Utilities.Security.Entities;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class AuthManager:IAuthService
{
    private readonly IUserService _userService;
    private readonly ITokenHelper _tokenHelper;
    private readonly IUserOperationClaimRepository _userOperationClaimRepository;
    private readonly IUserRepository _userRepository;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IInstructorRepository _instructorRepository;
    private readonly IApplicantRepository _applicantRepository;
    private readonly UserBusinessRules _rules;

    public AuthManager(IUserService userService, ITokenHelper tokenHelper, IUserOperationClaimRepository userOperationClaimRepository, IUserRepository userRepository,IEmployeeRepository employeeRepository,IInstructorRepository instructorRepository,IApplicantRepository applicantRepository,UserBusinessRules rules)
    {
        _userService = userService;
        _tokenHelper = tokenHelper;
        _userOperationClaimRepository = userOperationClaimRepository;
        _userRepository = userRepository;
        _rules = rules;
        _applicantRepository = applicantRepository;
        _employeeRepository = employeeRepository;
        _instructorRepository = instructorRepository;
    }

    public async Task<DataResult<AccessToken>> CreateAccessToken(User user)
    {
        List<OperationClaim> claims = await _userOperationClaimRepository.Query()
            .AsNoTracking().Where(x => x.UserId == user.Id).Select(x => new OperationClaim
            {
                Id = x.OperationClaimId,
                Name = x.OperationClaim.Name
            }).ToListAsync();
        var accessToken = _tokenHelper.CreateToken(user, claims);
        return new SuccessDataResult<AccessToken>(accessToken, "Created Token");

    }

    public async Task<DataResult<AccessToken>> Login(UserForLoginDto userForLoginDto)
    {
        var user = await _userService.GetByMail(userForLoginDto.Email);
        await _rules.UserShouldBeExists(user.Data);
        await _rules.UserEmailShouldBeExists(userForLoginDto.Email);
        await _rules.UserPasswordShouldBeMatch(user.Data.Id, userForLoginDto.Password);
        var createAccessToken = await CreateAccessToken(user.Data);
        return new SuccessDataResult<AccessToken>(createAccessToken.Data, "Login Success");
    }


    public async Task<DataResult<AccessToken>> EmployeeRegister(EmployeeForRegisterDto employeeForRegisterDto)
    {
        await _rules.UserEmailShouldBeNotExists(employeeForRegisterDto.Email);
        byte[] passwordHash, passwordSalt;
        HashingHelper.CreatePasswordHash(employeeForRegisterDto.Password, out passwordHash, out passwordSalt);
        var employee = new Employee
        {
            UserName = employeeForRegisterDto.UserName,
            NationalIdentity = employeeForRegisterDto.NationalIdentity,
            DateOfBirth = employeeForRegisterDto.DateOfBirth,
            Email = employeeForRegisterDto.Email,
            FirstName = employeeForRegisterDto.FirstName,
            LastName = employeeForRegisterDto.LastName,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
            Position = employeeForRegisterDto.Position,
        };
        await _employeeRepository.AddAsync(employee);
        var createAccessToken = await CreateAccessToken(employee);
        return new SuccessDataResult<AccessToken>(createAccessToken.Data, "Register Success");
    }

    public async Task<DataResult<AccessToken>> InstructorRegister(InstructorForRegisterDto instructorForRegisterDto)
    {
        await _rules.UserEmailShouldBeNotExists(instructorForRegisterDto.Email);
        byte[] passwordHash, passwordSalt;
        HashingHelper.CreatePasswordHash(instructorForRegisterDto.Password, out passwordHash, out passwordSalt);
        var instructor = new Instructor
        {
            UserName = instructorForRegisterDto.UserName,
            NationalIdentity = instructorForRegisterDto.NationalIdentity,
            DateOfBirth = instructorForRegisterDto.DateOfBirth,
            Email = instructorForRegisterDto.Email,
            FirstName = instructorForRegisterDto.FirstName,
            LastName = instructorForRegisterDto.LastName,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
            CompanyName = instructorForRegisterDto.CompanyName,
        };
        await _instructorRepository.AddAsync(instructor);
        var createAccessToken = await CreateAccessToken(instructor);
        return new SuccessDataResult<AccessToken>(createAccessToken.Data, "Register Success");
    }

    public async Task<DataResult<AccessToken>> ApplicantRegister(ApplicantForRegisterDto applicantForRegisterDto)
    {
        await _rules.UserEmailShouldBeNotExists(applicantForRegisterDto.Email);
        byte[] passwordHash, passwordSalt;
        HashingHelper.CreatePasswordHash(applicantForRegisterDto.Password, out passwordHash, out passwordSalt);
        var applicant = new Applicant
        {
            UserName = applicantForRegisterDto.UserName,
            NationalIdentity = applicantForRegisterDto.NationalIdentity,
            DateOfBirth = applicantForRegisterDto.DateOfBirth,
            Email = applicantForRegisterDto.Email,
            FirstName = applicantForRegisterDto.FirstName,
            LastName = applicantForRegisterDto.LastName,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
            About = applicantForRegisterDto.About,
        };
        await _applicantRepository.AddAsync(applicant);
        var createAccessToken = await CreateAccessToken(applicant);
        return new SuccessDataResult<AccessToken>(createAccessToken.Data, "Register Success");
    }
}
