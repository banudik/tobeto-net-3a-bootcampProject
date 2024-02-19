using Business.Requests.Instructor;
using Business.Requests.User;
using Business.Responses.Instructor;
using Business.Responses.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts.User;

public interface IUserService
{
    Task<CreatedUserResponse> AddAsync(CreateUserRequest request);
    Task<UpdatedUserResponse> UpdateAsync(UpdateUserRequest request);
    Task<DeletedUserResponse> DeleteAsync(DeleteUserRequest request);
    Task<List<GetAllUserResponse>> GetAllAsync();
    Task<GetByIdUserResponse> GetByIdAsync(int id);
}
