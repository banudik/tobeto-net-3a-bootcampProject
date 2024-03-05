using AutoMapper;
using Business.Abstracts.ApplicationStates;
using Business.Constants;
using Business.Requests.ApplicationStates;
using Business.Responses.ApplicationStates;
using Business.Rules;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes.ApplicationStates;

public class ApplicationStateManager : IApplicationStateService
{

    private readonly IApplicationStateRepository _applicationStateRepository;
    private readonly IMapper _mapper;
    private readonly ApplicationStateBusinessRules _rules;

    public ApplicationStateManager(IApplicationStateRepository applicationRepository, IMapper mapper, ApplicationStateBusinessRules rules)
    {
        _applicationStateRepository = applicationRepository;
        _mapper = mapper;
        _rules = rules;
    }
    [LogAspect(typeof(MongoDbLogger))]
    public async Task<IDataResult<CreatedApplicationStateResponse>> AddAsync(CreateApplicationStateRequest request)
    {
        ApplicationState applicationState = _mapper.Map<ApplicationState>(request);
        await _applicationStateRepository.AddAsync(applicationState);
        CreatedApplicationStateResponse response = _mapper.Map<CreatedApplicationStateResponse>(applicationState);
        return new SuccessDataResult<CreatedApplicationStateResponse>(response, ApplicationStateMessages.ApplicationStateAdded);
    }
    [LogAspect(typeof(MongoDbLogger))]
    public async Task<IResult> DeleteAsync(DeleteApplicationStateRequest request)
    {
        await _rules.CheckIdIfNotExist(request.Id);

        var item = await _applicationStateRepository.GetAsync(x => x.Id == request.Id);
        await _applicationStateRepository.DeleteAsync(item);

        return new SuccessResult(ApplicationStateMessages.ApplicationStateDeleted);
    }

    public async Task<IDataResult<List<GetAllApplicationStateResponse>>> GetAllAsync()
    {
        var list = await _applicationStateRepository.GetAllAsync();
        List<GetAllApplicationStateResponse> response = _mapper.Map<List<GetAllApplicationStateResponse>>(list);
        return new SuccessDataResult<List<GetAllApplicationStateResponse>>(response, ApplicationStateMessages.ApplicationStateListed);
    }

    public async Task<IDataResult<GetByIdApplicationStateResponse>> GetByIdAsync(int id)
    {
        await _rules.CheckIdIfNotExist(id);

        var item = await _applicationStateRepository.GetAsync(x => x.Id == id);

        GetByIdApplicationStateResponse response = _mapper.Map<GetByIdApplicationStateResponse>(item);

        return new SuccessDataResult<GetByIdApplicationStateResponse>(response, ApplicationStateMessages.ApplicationStateFound);


    }
    [LogAspect(typeof(MongoDbLogger))]
    public async Task<IDataResult<UpdatedApplicationStateResponse>> UpdateAsync(UpdateApplicationStateRequest request)
    {
        await _rules.CheckIdIfNotExist(request.Id);

        var item = await _applicationStateRepository.GetAsync(p => p.Id == request.Id);

        _mapper.Map(request, item);
        await _applicationStateRepository.UpdateAsync(item);

        UpdatedApplicationStateResponse response = _mapper.Map<UpdatedApplicationStateResponse>(item);
        return new SuccessDataResult<UpdatedApplicationStateResponse>(response, ApplicationStateMessages.ApplicationStateUpdated);
    }


}
