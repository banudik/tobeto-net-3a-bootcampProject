using Business.Requests.Blacklists;
using Business.Responses.Blacklists;
using Core.Utilities.Results;

namespace Business.Abstracts.Blacklists;

public interface IBlacklistService
{
    Task<IDataResult<CreatedBlacklistResponse>> AddAsync(CreateBlacklistRequest request);
    Task<IDataResult<UpdatedBlacklistResponse>> UpdateAsync(UpdateBlacklistRequest request);
    Task<IResult> DeleteAsync(DeleteBlacklistRequest request);
    Task<IDataResult<List<GetAllBlacklistResponse>>> GetAllAsync();
    Task<IDataResult<GetByIdBlacklistResponse>> GetByIdAsync(int id);
    Task<IDataResult<GetByIdBlacklistResponse>> GetByApplicantIdAsync(int id);
}
