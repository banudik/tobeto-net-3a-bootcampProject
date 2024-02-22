using Business.Requests.Applications;
using Business.Requests.ApplicationStates;
using Business.Responses.Applications;
using Business.Responses.ApplicationStates;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts.ApplicationStates;

public interface IApplicationStateService
{
    public Task<IDataResult<CreatedApplicationStateResponse>> AddAsync(CreateApplicationStateRequest request);
    public Task<IDataResult<UpdatedApplicationStateResponse>> UpdateAsync(UpdateApplicationStateRequest request);
    public Task<IDataResult<DeletedApplicationStateResponse>> DeleteAsync(DeleteApplicationStateRequest request);
    public Task<IDataResult<List<GetAllApplicationStateResponse>>> GetAllAsync();
    public Task<IDataResult<GetByIdApplicationStateResponse>> GetByIdAsync(int id);
}
