using AutoMapper;
using Business.Abstracts.BootcampStates;
using Business.Constants;
using Business.Requests.BootcampStates;
using Business.Responses.BootcampStates;
using Business.Rules;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes.BootcampStates;

public class BootcampStateManager : IBootcampStateService
{
    private readonly IBootcampStateRepository _bootcampStateRepository;
    private readonly IMapper _mapper;
    private readonly BootcampStateBusinessRules _rules;

    public BootcampStateManager(IBootcampStateRepository bootcampStateRepository, IMapper mapper, BootcampStateBusinessRules rules)
    {
        _bootcampStateRepository = bootcampStateRepository;
        _mapper = mapper;
        _rules = rules;
    }
    [LogAspect(typeof(MongoDbLogger))]
    public async Task<IDataResult<CreatedBootcampStateResponse>> AddAsync(CreateBootcampStateRequest request)
    {
        BootcampState bootcampState = _mapper.Map<BootcampState>(request);
        await _bootcampStateRepository.AddAsync(bootcampState);
        CreatedBootcampStateResponse response = _mapper.Map<CreatedBootcampStateResponse>(bootcampState);
        return new SuccessDataResult<CreatedBootcampStateResponse>(response, BootcampStateMessages.BootcampStateAdded);
    }
    [LogAspect(typeof(MongoDbLogger))]
    public async Task<IResult> DeleteAsync(DeleteBootcampStateRequest request)
    {
        await _rules.CheckIdIfNotExist(request.Id);

        var item = await _bootcampStateRepository.GetAsync(x => x.Id == request.Id);
        await _bootcampStateRepository.DeleteAsync(item);

        return new SuccessResult(BootcampStateMessages.BootcampStateDeleted);
    }

    public async Task<IDataResult<List<GetAllBootcampStateResponse>>> GetAllAsync()
    {
        var list = await _bootcampStateRepository.GetAllAsync();
        List<GetAllBootcampStateResponse> response = _mapper.Map<List<GetAllBootcampStateResponse>>(list);
        return new SuccessDataResult<List<GetAllBootcampStateResponse>>(response, BootcampStateMessages.BootcampStateListed);
    }

    public async Task<IDataResult<GetByIdBootcampStateResponse>> GetByIdAsync(int id)
    {
        await _rules.CheckIdIfNotExist(id);

        var item = await _bootcampStateRepository.GetAsync(x => x.Id == id);

        GetByIdBootcampStateResponse response = _mapper.Map<GetByIdBootcampStateResponse>(item);


        return new SuccessDataResult<GetByIdBootcampStateResponse>(response, BootcampStateMessages.BootcampStateFound);


    }
    [LogAspect(typeof(MongoDbLogger))]
    public async Task<IDataResult<UpdatedBootcampStateResponse>> UpdateAsync(UpdateBootcampStateRequest request)
    {
        await _rules.CheckIdIfNotExist(request.Id);

        var item = await _bootcampStateRepository.GetAsync(p => p.Id == request.Id);
      

        _mapper.Map(request, item);
        await _bootcampStateRepository.UpdateAsync(item);

        UpdatedBootcampStateResponse response = _mapper.Map<UpdatedBootcampStateResponse>(item);
        return new SuccessDataResult<UpdatedBootcampStateResponse>(response, BootcampStateMessages.BootcampStateUpdated);
    }


}
