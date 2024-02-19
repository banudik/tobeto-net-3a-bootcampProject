using Business.Requests.Applicant;
using Business.Responses.Applicant;
using Entities.Concretes;

namespace Business.Abstracts;

public interface IApplicantService
{
    Task<CreatedApplicantResponse> AddAsync(CreateApplicantRequest request);
    Task<UpdatedApplicantResponse> UpdateAsync(UpdateApplicantRequest request);
    Task<DeletedApplicantResponse> DeleteAsync(DeleteApplicantRequest request);
    Task<List<GetAllApplicantResponse>> GetAllAsync();
    Task<GetByIdApplicantResponse> GetByIdAsync(int id);
   
}
