using Business.Requests.Instructor;
using Business.Responses.Instructor;
using Core.Utilities.Results;

namespace Business.Abstracts.Instructor;

public interface IInstructorService
{
    Task<IDataResult<CreatedInstructorResponse>> AddAsync(CreateInstructorRequest request);
    Task<IDataResult<UpdatedInstructorResponse>> UpdateAsync(UpdateInstructorRequest request);
    Task<IResult> DeleteAsync(DeleteInstructorRequest request);
    Task<IDataResult<List<GetAllInstructorResponse>>> GetAllAsync();
    Task<IDataResult<GetByIdInstructorResponse>> GetByIdAsync(int id);
}
