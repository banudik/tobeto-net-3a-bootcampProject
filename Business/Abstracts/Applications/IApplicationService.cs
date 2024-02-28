using Business.Requests.Applications;
using Business.Responses.Applications;
using Core.Utilities.Results;

namespace Business.Abstracts.Applications;

public interface IApplicationService
{
    Task<IDataResult<CreatedApplicationResponse>> AddAsync(CreateApplicationRequest request);
    Task<IDataResult<UpdatedApplicationResponse>> UpdateAsync(UpdateApplicationRequest request);
    Task<IResult> DeleteAsync(DeleteApplicationRequest request);
    Task<IDataResult<List<GetAllApplicationResponse>>> GetAllAsync();
    Task<IDataResult<GetByIdApplicationResponse>> GetByIdAsync(int id);
}
