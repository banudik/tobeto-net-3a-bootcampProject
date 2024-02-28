using Business.Requests.Bootcamps;
using Business.Responses.Bootcamps;
using Core.Utilities.Results;

namespace Business.Abstracts.Bootcamps;

public interface IBootcampService
{
     Task<IDataResult<CreatedBootcampResponse>> AddAsync(CreateBootcampRequest request);
    Task<IDataResult<UpdatedBootcampResponse>> UpdateAsync(UpdateBootcampRequest request);
    Task<IResult> DeleteAsync(DeleteBootcampRequest request);
    Task<IDataResult<List<GetAllBootcampResponse>>> GetAllAsync();
    Task<IDataResult<GetByIdBootcampResponse>> GetByIdAsync(int id);
}
