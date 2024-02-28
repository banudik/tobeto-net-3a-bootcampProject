using Business.Requests.User;
using Business.Responses.User;
using Core.Utilities.Results;

namespace Business.Abstracts.User;

public interface IUserService
{
    Task<IDataResult<CreatedUserResponse>> AddAsync(CreateUserRequest request);
    Task<IDataResult<UpdatedUserResponse>> UpdateAsync(UpdateUserRequest request);
    Task<IResult> DeleteAsync(DeleteUserRequest request);
    Task<IDataResult<List<GetAllUserResponse>>> GetAllAsync();
    Task<IDataResult<GetByIdUserResponse>> GetByIdAsync(int id);
}
