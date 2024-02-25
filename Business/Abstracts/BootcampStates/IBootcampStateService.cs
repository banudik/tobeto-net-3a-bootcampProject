using Business.Requests.BootcampStates;
using Business.Responses.BootcampStates;
using Core.Utilities.Results;

namespace Business.Abstracts.BootcampStates;

public interface IBootcampStateService
{
     Task<IDataResult<CreatedBootcampStateResponse>> AddAsync(CreateBootcampStateRequest request);
    Task<IDataResult<UpdatedBootcampStateResponse>> UpdateAsync(UpdateBootcampStateRequest request);
    Task<IDataResult<DeletedBootcampStateResponse>> DeleteAsync(DeleteBootcampStateRequest request);
    Task<IDataResult<List<GetAllBootcampStateResponse>>> GetAllAsync();
    Task<IDataResult<GetByIdBootcampStateResponse>> GetByIdAsync(int id);
}
