using AutoMapper;
using Azure.Core;
using Business.Abstracts.Blacklists;
using Business.Requests.Blacklists;
using Business.Responses.Applicant;
using Business.Responses.Blacklists;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using DataAccess.Concretes.Repositories;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes.Blacklists;

public class BlacklistManager : IBlacklistService
{
    private readonly IBlacklistRepository _blacklistRepository;
    private readonly IMapper _mapper;

    public BlacklistManager(IBlacklistRepository blacklistRepository, IMapper mapper)
    {
        _blacklistRepository = blacklistRepository;
        _mapper = mapper;
    }

    public async Task<IDataResult<CreatedBlacklistResponse>> AddAsync(CreateBlacklistRequest request)
    {
        Blacklist blacklist = _mapper.Map<Blacklist>(request);
        await _blacklistRepository.AddAsync(blacklist);
        CreatedBlacklistResponse response = _mapper.Map<CreatedBlacklistResponse>(blacklist);
        return new SuccessDataResult<CreatedBlacklistResponse>(response, "Added Successfully");
    }

    public async Task<IResult> DeleteAsync(DeleteBlacklistRequest request)
    {
        var item = await _blacklistRepository.GetAsync(x=> x.Id == request.Id);
        await _blacklistRepository.DeleteAsync(item);
        
        return new SuccessResult("Deleted Successfully");
    }

    public async Task<IDataResult<List<GetAllBlacklistResponse>>> GetAllAsync()
    {
        var list = await _blacklistRepository.GetAllAsync();
        List<GetAllBlacklistResponse> response = _mapper.Map<List<GetAllBlacklistResponse>>(list);
        return new SuccessDataResult<List<GetAllBlacklistResponse>>(response, "Listed Successfully");
    }

    public async Task<IDataResult<GetByIdBlacklistResponse>> GetByApplicantIdAsync(int id)
    {
        var item = await _blacklistRepository.GetAsync(x=>x.ApplicantId == id);
        if (item != null)
        {
            GetByIdBlacklistResponse response = _mapper.Map<GetByIdBlacklistResponse>(item);
            return new SuccessDataResult<GetByIdBlacklistResponse>(response, "Found Succesfully.");
        }
        return new ErrorDataResult<GetByIdBlacklistResponse>("BlackListed applicant could not be found.");
    }

    public async Task<IDataResult<GetByIdBlacklistResponse>> GetByIdAsync(int id)
    {
        var item = await _blacklistRepository.GetAsync(x => x.Id == id);

        GetByIdBlacklistResponse response = _mapper.Map<GetByIdBlacklistResponse>(item);

        if (item != null)
        {
            return new SuccessDataResult<GetByIdBlacklistResponse>(response, "Found Succesfully.");
        }
        return new ErrorDataResult<GetByIdBlacklistResponse>("Blacklist could not be found.");
    }

    public async Task<IDataResult<UpdatedBlacklistResponse>> UpdateAsync(UpdateBlacklistRequest request)
    {
        var item = await _blacklistRepository.GetAsync(x => x.Id == request.Id);
        if (request.Id == 0 || item == null)
        {
            return new ErrorDataResult<UpdatedBlacklistResponse>("Blacklist could not be found.");
        }

        _mapper.Map(request, item);
        await _blacklistRepository.UpdateAsync(item);

        UpdatedBlacklistResponse response = _mapper.Map<UpdatedBlacklistResponse>(item);
        return new SuccessDataResult<UpdatedBlacklistResponse>(response, "Blacklist updated successfully!");
    }
}
