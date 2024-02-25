using Business.Requests.ApplicationStates;
using Business.Responses.ApplicationStates;
using Core.Utilities.Results;

namespace Business.Abstracts.ApplicationStates;

public interface IApplicationStateService
{
    Task<IDataResult<CreatedApplicationStateResponse>> AddAsync(CreateApplicationStateRequest request);
    Task<IDataResult<UpdatedApplicationStateResponse>> UpdateAsync(UpdateApplicationStateRequest request);
    Task<IDataResult<DeletedApplicationStateResponse>> DeleteAsync(DeleteApplicationStateRequest request);
    Task<IDataResult<List<GetAllApplicationStateResponse>>> GetAllAsync();
    Task<IDataResult<GetByIdApplicationStateResponse>> GetByIdAsync(int id);
}
