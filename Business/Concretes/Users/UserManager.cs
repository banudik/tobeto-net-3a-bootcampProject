using AutoMapper;
using Business.Abstracts.User;
using Business.Constants;
using Business.Requests.User;
using Business.Responses.User;
using Business.Rules;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes;

public class UserManager : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly UserBusinessRules _rules;
    public UserManager(IUserRepository userRepository, IMapper mapper, UserBusinessRules rules)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _rules = rules;
    }
    [LogAspect(typeof(MongoDbLogger))]
    public async Task<IDataResult<CreatedUserResponse>> AddAsync(CreateUserRequest request)
    {
        User user = _mapper.Map<User>(request);
        await _userRepository.AddAsync(user);
        CreatedUserResponse response = _mapper.Map<CreatedUserResponse>(user);
        return new SuccessDataResult<CreatedUserResponse>(response, UserMessages.UserAdded);
    }
    [LogAspect(typeof(MongoDbLogger))]
    public async Task<IResult> DeleteAsync(DeleteUserRequest request)
    {
        await _rules.CheckIdIfNotExist(request.Id);
        var item = await _userRepository.GetAsync(x => x.Id == request.Id);
        await _userRepository.DeleteAsync(item);

        return new SuccessResult(UserMessages.UserDeleted);
    }

    public async Task<IDataResult<List<GetAllUserResponse>>> GetAllAsync()
    {
        var list = await _userRepository.GetAllAsync();
        List<GetAllUserResponse> response = _mapper.Map<List<GetAllUserResponse>>(list);
        return new SuccessDataResult<List<GetAllUserResponse>>(response, UserMessages.UserListed);
    }

    public async Task<IDataResult<GetByIdUserResponse>> GetByIdAsync(int id)
    {
        await _rules.CheckIdIfNotExist(id);

        var item = await _userRepository.GetAsync(x => x.Id == id);

        GetByIdUserResponse response = _mapper.Map<GetByIdUserResponse>(item);


        return new SuccessDataResult<GetByIdUserResponse>(response, UserMessages.UserFound);

    }
    [LogAspect(typeof(MongoDbLogger))]
    public async Task<IDataResult<UpdatedUserResponse>> UpdateAsync(UpdateUserRequest request)
    {
        await _rules.CheckIdIfNotExist(request.Id);

        var item = await _userRepository.GetAsync(p => p.Id == request.Id);

        _mapper.Map(request, item);
        await _userRepository.UpdateAsync(item);

        UpdatedUserResponse response = _mapper.Map<UpdatedUserResponse>(item);
        return new SuccessDataResult<UpdatedUserResponse>(response, UserMessages.UserUpdated);
    }


}
