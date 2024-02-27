using Business.Requests.Applicant;
using Business.Responses.Applicant;
using Core.Utilities.Results;

namespace Business.Abstracts;

public interface IApplicantService
{
    Task<IDataResult<CreatedApplicantResponse>> AddAsync(CreateApplicantRequest request);
    Task<IDataResult<UpdatedApplicantResponse>> UpdateAsync(UpdateApplicantRequest request);
    Task<IDataResult<DeletedApplicantResponse>> DeleteAsync(DeleteApplicantRequest request);
    Task<IDataResult<List<GetAllApplicantResponse>>> GetAllAsync();
    Task<IDataResult<GetByIdApplicantResponse>> GetByIdAsync(int id);
   
}
