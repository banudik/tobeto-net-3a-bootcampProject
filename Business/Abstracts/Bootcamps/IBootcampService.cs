using Business.Requests.ApplicationStates;
using Business.Requests.Bootcamps;
using Business.Responses.ApplicationStates;
using Business.Responses.Bootcamps;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts.Bootcamps;

public interface IBootcampService
{
    public Task<IDataResult<CreatedBootcampResponse>> AddAsync(CreateBootcampRequest request);
    public Task<IDataResult<UpdatedBootcampResponse>> UpdateAsync(UpdateBootcampRequest request);
    public Task<IDataResult<DeletedBootcampResponse>> DeleteAsync(DeleteBootcampRequest request);
    public Task<IDataResult<List<GetAllBootcampResponse>>> GetAllAsync();
    public Task<IDataResult<GetByIdBootcampResponse>> GetByIdAsync(int id);
}
