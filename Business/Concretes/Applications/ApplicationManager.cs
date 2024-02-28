using AutoMapper;
using Business.Abstracts.Applications;
using Business.Abstracts.Blacklists;
using Business.Requests.Applications;
using Business.Responses.Applications;
using Core.Exceptions.Types;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using DataAccess.Concretes.Repositories;
using Entities.Concretes;

namespace Business.Concretes.Applications;

public class ApplicationManager : IApplicationService
{
    private readonly IApplicationRepository _applicationRepository;
    private readonly IMapper _mapper;
    private readonly IBlacklistService _blacklistService;

    public ApplicationManager(IApplicationRepository applicationRepository, IMapper mapper, IBlacklistService blacklistService)
    {
        _applicationRepository = applicationRepository;
        _mapper = mapper;
        _blacklistService = blacklistService;

    }

    public async Task<IDataResult<CreatedApplicationResponse>> AddAsync(CreateApplicationRequest request)
    {
        await CheckIfApplicantIsBlacklisted(request.ApplicantId);

        Application application = _mapper.Map<Application>(request);
        await _applicationRepository.AddAsync(application);
        CreatedApplicationResponse response = _mapper.Map<CreatedApplicationResponse>(application);
        return new SuccessDataResult<CreatedApplicationResponse>(response, "Added Successfully");
    }

    public async Task<IResult> DeleteAsync(DeleteApplicationRequest request)
    {
        var item = await _applicationRepository.GetAsync(x=>x.Id == request.Id);
        await _applicationRepository.DeleteAsync(item);
        
        return new SuccessResult("Deleted Successfully");
    }

    public async Task<IDataResult<List<GetAllApplicationResponse>>> GetAllAsync()
    {
        var list = await _applicationRepository.GetAllAsync();
        List<GetAllApplicationResponse> response = _mapper.Map<List<GetAllApplicationResponse>>(list);
        return new SuccessDataResult<List<GetAllApplicationResponse>>(response, "Listed Successfully");
    }

    public async Task<IDataResult<GetByIdApplicationResponse>> GetByIdAsync(int id)
    {
        var item = await _applicationRepository.GetAsync(x => x.Id == id);

        GetByIdApplicationResponse response = _mapper.Map<GetByIdApplicationResponse>(item);

        if (item != null)
        {
            return new SuccessDataResult<GetByIdApplicationResponse>(response, "Found Succesfully.");
        }
        return new ErrorDataResult<GetByIdApplicationResponse>("Application could not be found.");
    }

    public async Task<IDataResult<UpdatedApplicationResponse>> UpdateAsync(UpdateApplicationRequest request)
    {
        var item = await _applicationRepository.GetAsync(p => p.Id == request.Id);
        if (request.Id == 0 || item == null)
        {
            return new ErrorDataResult<UpdatedApplicationResponse>("Application could not be found.");
        }

        _mapper.Map(request, item);
        await _applicationRepository.UpdateAsync(item);

        UpdatedApplicationResponse response = _mapper.Map<UpdatedApplicationResponse>(item);
        return new SuccessDataResult<UpdatedApplicationResponse>(response, "Application updated successfully!");
    }

    public async Task CheckIfApplicantIsBlacklisted(int id)
    {
        var item = await _blacklistService.GetByApplicantIdAsync(id);            if (item.Data != null)
        {
            throw new BusinessException("Applicant is blacklisted");
        }
    }


}
