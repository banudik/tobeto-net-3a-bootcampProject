using Business.Requests.Bootcamps;
using Business.Requests.BootcampStates;
using Business.Responses.Bootcamps;
using Business.Responses.BootcampStates;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts.BootcampStates;

public interface IBootcampStateService
{
    public Task<IDataResult<CreatedBootcampStateResponse>> AddAsync(CreateBootcampStateRequest request);
    public Task<IDataResult<UpdatedBootcampStateResponse>> UpdateAsync(UpdateBootcampStateRequest request);
    public Task<IDataResult<DeletedBootcampStateResponse>> DeleteAsync(DeleteBootcampStateRequest request);
    public Task<IDataResult<List<GetAllBootcampStateResponse>>> GetAllAsync();
    public Task<IDataResult<GetByIdBootcampStateResponse>> GetByIdAsync(int id);
}
