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
        applicantToCreate.About = request.About;
        await _applicantRepository.Add(applicantToCreate);

        CreatedApplicantResponse response = new CreatedApplicantResponse();
        response.About = applicantToCreate.About;
        return response;
    }

    public async Task<DeletedApplicantResponse> DeleteAsync(DeleteApplicantRequest request)
    {
        Applicant applicantToDelete = new Applicant();
        applicantToDelete.Id = request.Id;
        await _applicantRepository.Delete(applicantToDelete);

        DeletedApplicantResponse response = new DeletedApplicantResponse();
        response.Id = applicantToDelete.Id;
        return response;

    }

    public async Task<List<GetAllApplicantResponse>> GetAllAsync()
    {
        List<GetAllApplicantResponse> applicants = new List<GetAllApplicantResponse>();
        foreach (var applicant in await _applicantRepository.GetAll())
        {
            GetAllApplicantResponse response = new GetAllApplicantResponse();
            response.Id = applicant.Id;
            response.About = applicant.About;
            applicants.Add(response);
        }
        return applicants;

    }

    public async Task<GetByIdApplicantResponse> GetByIdAsync(int id)
    {
        GetByIdApplicantResponse response = new GetByIdApplicantResponse();
        Applicant applicant = await _applicantRepository.Get(x => x.Id == id);
        response.Id = applicant.Id;
        response.About = applicant.About;
        return response;
    }

    public async Task<UpdatedApplicantResponse> UpdateAsync(UpdateApplicantRequest request)
    {
        Applicant applicantToUpdate = await _applicantRepository.Get(x => x.Id == request.Id);
        applicantToUpdate.Id = request.Id;
        applicantToUpdate.About = request.About;
        await _applicantRepository.Update(applicantToUpdate);

        UpdatedApplicantResponse response = new UpdatedApplicantResponse();
        response.Id = applicantToUpdate.Id;
        response.About = applicantToUpdate.About;
        return response;

    }
}
