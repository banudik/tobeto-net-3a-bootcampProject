using Business.Abstracts;
using Business.Requests.Applicant;
using Business.Responses.Applicant;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes;

public class ApplicantManager : IApplicantService
{
    private readonly IApplicantRepository _applicantRepository;

    public ApplicantManager(IApplicantRepository applicantRepository)
    {
        _applicantRepository = applicantRepository;
    }

    public async Task<CreatedApplicantResponse> AddAsync(CreateApplicantRequest request)
    {
        Applicant applicantToCreate = new Applicant();
        applicantToCreate.UserName = request.UserName;
        applicantToCreate.FirstName = request.FirstName;
        applicantToCreate.LastName = request.LastName;
        applicantToCreate.DateOfBirth = request.DateOfBirth;
        applicantToCreate.NationalIdentity = request.NationalIdentity;
        applicantToCreate.Email = request.Email;
        applicantToCreate.Password = request.Password;
        applicantToCreate.About = request.About;
        await _applicantRepository.AddAsync(applicantToCreate);

        CreatedApplicantResponse response = new CreatedApplicantResponse();
        response.UserName = applicantToCreate.UserName;
        response.FirstName = applicantToCreate.FirstName;
        response.LastName = applicantToCreate.LastName;
        response.DateOfBirth = applicantToCreate.DateOfBirth;
        response.NationalIdentity = applicantToCreate.NationalIdentity;
        response.Email = applicantToCreate.Email;
        response.Password = applicantToCreate.Password;
        response.About = applicantToCreate.About;
        return response;
    }

    public async Task<DeletedApplicantResponse> DeleteAsync(DeleteApplicantRequest request)
    {
        Applicant applicantToDelete = new Applicant();
        applicantToDelete.Id = request.Id;
        await _applicantRepository.DeleteAsync(applicantToDelete);

        DeletedApplicantResponse response = new DeletedApplicantResponse();
        response.Id = applicantToDelete.Id;
        return response;

    }

    public async Task<List<GetAllApplicantResponse>> GetAllAsync()
    {
        List<GetAllApplicantResponse> applicants = new List<GetAllApplicantResponse>();
        foreach (var applicant in await _applicantRepository.GetAllAsync())
        {
            GetAllApplicantResponse response = new GetAllApplicantResponse();
            response.Id = applicant.Id;
            response.UserName = applicant.UserName;
            response.FirstName = applicant.FirstName;
            response.LastName = applicant.LastName;
            response.DateOfBirth = applicant.DateOfBirth;
            response.NationalIdentity = applicant.NationalIdentity;
            response.Email = applicant.Email;
            response.Password = applicant.Password;
            response.About = applicant.About;
            applicants.Add(response);
        }
        return applicants;

    }

    public async Task<GetByIdApplicantResponse> GetByIdAsync(int id)
    {
        GetByIdApplicantResponse response = new GetByIdApplicantResponse();
        Applicant applicant = await _applicantRepository.GetAsync(x => x.Id == id);
        response.Id = applicant.Id;
        response.UserName = applicant.UserName;
        response.FirstName = applicant.FirstName;
        response.LastName = applicant.LastName;
        response.DateOfBirth = applicant.DateOfBirth;
        response.NationalIdentity = applicant.NationalIdentity;
        response.Email = applicant.Email;
        response.Password = applicant.Password;
        response.About = applicant.About;
        return response;
    }

    public async Task<UpdatedApplicantResponse> UpdateAsync(UpdateApplicantRequest request)
    {
        Applicant applicantToUpdate = await _applicantRepository.GetAsync(x => x.Id == request.Id);
        applicantToUpdate.Id = request.Id;
        applicantToUpdate.UserName = request.UserName;
        applicantToUpdate.FirstName = request.FirstName;
        applicantToUpdate.LastName = request.LastName;
        applicantToUpdate.DateOfBirth = request.DateOfBirth;
        applicantToUpdate.NationalIdentity = request.NationalIdentity;
        applicantToUpdate.Email = request.Email;
        applicantToUpdate.Password = request.Password;
        applicantToUpdate.About = request.About;
        await _applicantRepository.UpdateAsync(applicantToUpdate);

        UpdatedApplicantResponse response = new UpdatedApplicantResponse();
        response.Id = applicantToUpdate.Id;
        response.UserName = applicantToUpdate.UserName;
        response.FirstName = applicantToUpdate.FirstName;
        response.LastName = applicantToUpdate.LastName;
        response.DateOfBirth = applicantToUpdate.DateOfBirth;
        response.NationalIdentity = applicantToUpdate.NationalIdentity;
        response.Email = applicantToUpdate.Email;
        response.Password = applicantToUpdate.Password;
        response.About = applicantToUpdate.About;
        return response;

    }
}
