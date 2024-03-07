using AutoMapper;
using Business.Abstracts.Blacklists;
using Business.Constants;
using Business.Requests.Blacklists;
using Business.Responses.Blacklists;
using Business.Rules;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes.Blacklists;

public class BlacklistManager : IBlacklistService
{
    private readonly IBlacklistRepository _blacklistRepository;
    private readonly IMapper _mapper;
    private readonly BlacklistBusinessRules _rules;

    public BlacklistManager(IBlacklistRepository blacklistRepository, IMapper mapper, BlacklistBusinessRules rules)
    {
        _blacklistRepository = blacklistRepository;
        _mapper = mapper;
        _rules = rules;

    }
    [LogAspect(typeof(MongoDbLogger))]
    public async Task<IDataResult<CreatedBlacklistResponse>> AddAsync(CreateBlacklistRequest request)
    {
        Blacklist blacklist = _mapper.Map<Blacklist>(request);
        await _blacklistRepository.AddAsync(blacklist);
        CreatedBlacklistResponse response = _mapper.Map<CreatedBlacklistResponse>(blacklist);
        return new SuccessDataResult<CreatedBlacklistResponse>(response, BlacklistMessages.BlacklistAdded);
    }
    [LogAspect(typeof(MongoDbLogger))]
    public async Task<IResult> DeleteAsync(DeleteBlacklistRequest request)
    {
        await _rules.CheckIdIfNotExist(request.Id);

        var item = await _blacklistRepository.GetAsync(x => x.Id == request.Id);
        await _blacklistRepository.DeleteAsync(item);

        return new SuccessResult(BlacklistMessages.BlacklistDeleted);
    }

    public async Task<IDataResult<List<GetAllBlacklistResponse>>> GetAllAsync()
    {
        var list = await _blacklistRepository.GetAllAsync(include: x => x.Include(y => y.Applicant));
        List<GetAllBlacklistResponse> response = _mapper.Map<List<GetAllBlacklistResponse>>(list);
        return new SuccessDataResult<List<GetAllBlacklistResponse>>(response, BlacklistMessages.BlacklistListed);
    }

    public async Task<IDataResult<GetByIdBlacklistResponse>> GetByApplicantIdAsync(int id)
    {
        await _rules.CheckIdIfExist(id);

        var item = await _blacklistRepository.GetAsync(x => x.ApplicantId == id);

        GetByIdBlacklistResponse response = _mapper.Map<GetByIdBlacklistResponse>(item);
        return new SuccessDataResult<GetByIdBlacklistResponse>(response, BlacklistMessages.BlacklistFound);


    }

    public async Task<IDataResult<GetByIdBlacklistResponse>> GetByIdAsync(int id)
    {
        await _rules.CheckIdIfNotExist(id);

        var item = await _blacklistRepository.GetAsync(x => x.Id == id, include: x => x.Include(y => y.Applicant));

        GetByIdBlacklistResponse response = _mapper.Map<GetByIdBlacklistResponse>(item);

        return new SuccessDataResult<GetByIdBlacklistResponse>(response, BlacklistMessages.BlacklistFound);


    }
    [LogAspect(typeof(MongoDbLogger))]
    public async Task<IDataResult<UpdatedBlacklistResponse>> UpdateAsync(UpdateBlacklistRequest request)
    {
        await _rules.CheckIdIfNotExist(request.Id);

        var item = await _blacklistRepository.GetAsync(x => x.Id == request.Id, include: x => x.Include(y => y.Applicant));
        
        _mapper.Map(request, item);
        await _blacklistRepository.UpdateAsync(item);

        UpdatedBlacklistResponse response = _mapper.Map<UpdatedBlacklistResponse>(item);
        return new SuccessDataResult<UpdatedBlacklistResponse>(response, BlacklistMessages.BlacklistUpdated);
    }
}
