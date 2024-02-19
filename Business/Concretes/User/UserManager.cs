using Business.Abstracts.User;
using Business.Requests.User;
using Business.Responses.User;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes;

public class UserManager : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserManager(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<CreatedUserResponse> AddAsync(CreateUserRequest request)
    {
        User userToCreate = new User();
        userToCreate.UserName = request.UserName;
        userToCreate.FirstName = request.FirstName;
        userToCreate.LastName = request.LastName;
        userToCreate.DateOfBirth = request.DateOfBirth;
        userToCreate.NationalIdentity = request.NationalIdentity;
        userToCreate.Email = request.Email;
        userToCreate.Password = request.Password;
        await _userRepository.AddAsync(userToCreate);

        CreatedUserResponse response = new CreatedUserResponse();
        response.UserName = userToCreate.UserName;
        response.FirstName = userToCreate.FirstName;
        response.LastName = userToCreate.LastName;
        response.DateOfBirth= userToCreate.DateOfBirth;
        response.NationalIdentity = userToCreate.NationalIdentity;
        response.Email = userToCreate.Email;
        response.Password = userToCreate.Password;
        return response;
    }

    public async Task<DeletedUserResponse> DeleteAsync(DeleteUserRequest request)
    {
        User userToDelete = new User();
        userToDelete.Id = request.Id;
        await _userRepository.DeleteAsync(userToDelete);

        DeletedUserResponse response = new DeletedUserResponse();
        response.Id = userToDelete.Id;
        return response;
        
    }

    public async Task<List<GetAllUserResponse>> GetAllAsync()
    {
        List<GetAllUserResponse> users = new List<GetAllUserResponse>();
        foreach (var user in await  _userRepository.GetAllAsync())
        {
            GetAllUserResponse response = new GetAllUserResponse();
            response.Id= user.Id;
            response.UserName = user.UserName;
            response.FirstName = user.FirstName;
            response.LastName = user.LastName;
            response.DateOfBirth = user.DateOfBirth;
            response.NationalIdentity = user.NationalIdentity;
            response.Email = user.Email;
            response.Password = user.Password;
            users.Add(response);
        }
        return users;
    }

    public async Task<GetByIdUserResponse> GetByIdAsync(int id)
    {
        GetByIdUserResponse response = new GetByIdUserResponse();
        User user = await _userRepository.GetAsync(x => x.Id == id);
        response.Id = user.Id;
        response.UserName= user.UserName;
        response.FirstName = user.FirstName;
        response.LastName = user.LastName;
        response.DateOfBirth= user.DateOfBirth;
        response.NationalIdentity = user.NationalIdentity;
        response.Email = user.Email;
        response.Password = user.Password;
        return response;

    }

    public async Task<UpdatedUserResponse> UpdateAsync(UpdateUserRequest request)
    {
        User userToUpdate = await _userRepository.GetAsync(x => x.Id == request.Id);
        userToUpdate.UserName = request.UserName;
        userToUpdate.FirstName = request.FirstName;
        userToUpdate.LastName = request.LastName;
        userToUpdate.DateOfBirth = request.DateOfBirth;
        userToUpdate.NationalIdentity = request.NationalIdentity;
        userToUpdate.Email = request.Email;
        userToUpdate.Password = request.Password;
        await _userRepository.UpdateAsync(userToUpdate);

        UpdatedUserResponse response = new UpdatedUserResponse();
        response.UserName = userToUpdate.UserName;
        response.FirstName = userToUpdate.FirstName;
        response.LastName = userToUpdate.LastName;
        response.DateOfBirth = userToUpdate.DateOfBirth;
        response.NationalIdentity= userToUpdate.NationalIdentity;
        response.Email = userToUpdate.Email;
        response.Password = userToUpdate.Password;
        return response;
    }
}
