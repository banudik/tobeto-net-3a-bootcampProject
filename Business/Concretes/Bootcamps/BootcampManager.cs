using AutoMapper;
using Business.Abstracts.Bootcamps;
using Business.Constants;
using Business.Requests.Bootcamps;
using Business.Responses.Bootcamps;
using Business.Rules;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes.Bootcamps;

public class BootcampManager:IBootcampService
{
    private readonly IBootcampRepository _bootcampRepository;
    private readonly IMapper _mapper;
    private readonly BootcampBusinessRules _rules;

    public BootcampManager(IBootcampRepository bootcampRepository, IMapper mapper, BootcampBusinessRules rules)
    {
        _bootcampRepository = bootcampRepository;
        _mapper = mapper;
        _rules = rules;
    }
    [LogAspect(typeof(MongoDbLogger))]
    public async Task<IDataResult<CreatedBootcampResponse>> AddAsync(CreateBootcampRequest request)
    {
        Bootcamp bootcamp = _mapper.Map<Bootcamp>(request);
        await _bootcampRepository.AddAsync(bootcamp);
        CreatedBootcampResponse response = _mapper.Map<CreatedBootcampResponse>(bootcamp);
        return new SuccessDataResult<CreatedBootcampResponse>(response, BootcampMessages.BootcampAdded);
    }
    [LogAspect(typeof(MongoDbLogger))]
    public async Task<IResult> DeleteAsync(DeleteBootcampRequest request)
    {
        await _rules.CheckIdIfNotExist(request.Id);

        var item = await _bootcampRepository.GetAsync(x=> x.Id == request.Id);  
        await _bootcampRepository.DeleteAsync(item);
        
        return new SuccessResult(BootcampMessages.BootcampDeleted);
    }

    public async Task<IDataResult<List<GetAllBootcampResponse>>> GetAllAsync()
    {
        var list = await _bootcampRepository.GetAllAsync(include: x => x.Include(y => y.Instructor).Include(y=>y.BootcampState));
        List<GetAllBootcampResponse> response = _mapper.Map<List<GetAllBootcampResponse>>(list);
        return new SuccessDataResult<List<GetAllBootcampResponse>>(response, BootcampMessages.BootcampListed);
    }

    public async Task<IDataResult<GetByIdBootcampResponse>> GetByIdAsync(int id)
    {
        await _rules.CheckIdIfNotExist(id);

        var item = await _bootcampRepository.GetAsync(x => x.Id == id, include: x => x.Include(y => y.Instructor).Include(y => y.BootcampState));

        GetByIdBootcampResponse response = _mapper.Map<GetByIdBootcampResponse>(item);

            return new SuccessDataResult<GetByIdBootcampResponse>(response, BootcampMessages.BootcampFound);
       
    }
    [LogAspect(typeof(MongoDbLogger))]
    public async Task<IDataResult<UpdatedBootcampResponse>> UpdateAsync(UpdateBootcampRequest request)
    {
        await _rules.CheckIdIfNotExist(request.Id);
        var item = await _bootcampRepository.GetAsync(p => p.Id == request.Id, include: x => x.Include(y => y.Instructor).Include(y => y.BootcampState));
        

        _mapper.Map(request, item);
        await _bootcampRepository.UpdateAsync(item);

        UpdatedBootcampResponse response = _mapper.Map<UpdatedBootcampResponse>(item);
        return new SuccessDataResult<UpdatedBootcampResponse>(response, BootcampMessages.BootcampUpdated);
    }

    
}
