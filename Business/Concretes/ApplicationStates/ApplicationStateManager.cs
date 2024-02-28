using AutoMapper;
using Business.Abstracts.ApplicationStates;
using Business.Requests.ApplicationStates;
using Business.Responses.ApplicationStates;
using Core.Exceptions.Types;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes.ApplicationStates;

public class ApplicationStateManager : IApplicationStateService
{

    private readonly IApplicationStateRepository _applicationStateRepository;
    private readonly IMapper _mapper;

    public ApplicationStateManager(IApplicationStateRepository applicationRepository, IMapper mapper)
    {
        _applicationStateRepository = applicationRepository;
        _mapper = mapper;
    }

    public async Task<IDataResult<CreatedApplicationStateResponse>> AddAsync(CreateApplicationStateRequest request)
    {
        ApplicationState applicationState = _mapper.Map<ApplicationState>(request);
        await _applicationStateRepository.AddAsync(applicationState);
        CreatedApplicationStateResponse response = _mapper.Map<CreatedApplicationStateResponse>(applicationState);
        return new SuccessDataResult<CreatedApplicationStateResponse>(response, "Added Successfully");
    }

    public async Task<IResult> DeleteAsync(DeleteApplicationStateRequest request)
    {
        await CheckIdIfNotExist(request.Id);

        var item = await _applicationStateRepository.GetAsync(x => x.Id == request.Id);
        await _applicationStateRepository.DeleteAsync(item);

        return new SuccessResult("Deleted Successfully");
    }

    public async Task<IDataResult<List<GetAllApplicationStateResponse>>> GetAllAsync()
    {
        var list = await _applicationStateRepository.GetAllAsync();
        List<GetAllApplicationStateResponse> response = _mapper.Map<List<GetAllApplicationStateResponse>>(list);
        return new SuccessDataResult<List<GetAllApplicationStateResponse>>(response, "Listed Successfully");
    }

    public async Task<IDataResult<GetByIdApplicationStateResponse>> GetByIdAsync(int id)
    {
        await CheckIdIfNotExist(id);

        var item = await _applicationStateRepository.GetAsync(x => x.Id == id);

        GetByIdApplicationStateResponse response = _mapper.Map<GetByIdApplicationStateResponse>(item);

            return new SuccessDataResult<GetByIdApplicationStateResponse>(response, "Found Succesfully.");
       
        
    }

    public async Task<IDataResult<UpdatedApplicationStateResponse>> UpdateAsync(UpdateApplicationStateRequest request)
    {
        var item = await _applicationStateRepository.GetAsync(p => p.Id == request.Id);
        if (request.Id == 0 || item == null)
        {
            return new ErrorDataResult<UpdatedApplicationStateResponse>("ApplicationState could not be found.");
        }

        _mapper.Map(request, item);
        await _applicationStateRepository.UpdateAsync(item);

        UpdatedApplicationStateResponse response = _mapper.Map<UpdatedApplicationStateResponse>(item);
        return new SuccessDataResult<UpdatedApplicationStateResponse>(response, "ApplicationState succesfully updated!");
    }

    public async Task CheckIdIfNotExist(int id)
    {
        var item = await _applicationStateRepository.GetAsync(x => x.Id == id);
        if (item == null)
        {
            throw new NotFoundException("ID could not be found.");
        }
    }
}
