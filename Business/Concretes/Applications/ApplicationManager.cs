using AutoMapper;
using Business.Abstracts.Applications;
using Business.Requests.Applications;
using Business.Responses.Applications;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes.Applications;

public class ApplicationManager : IApplicationService
{
    private readonly IApplicationRepository _applicationRepository;
    private readonly IMapper _mapper;

    public ApplicationManager(IApplicationRepository applicationRepository, IMapper mapper)
    {
        _applicationRepository = applicationRepository;
        _mapper = mapper;
    }

    public async Task<IDataResult<CreatedApplicationResponse>> AddAsync(CreateApplicationRequest request)
    {
        Application application = _mapper.Map<Application>(request);
        await _applicationRepository.AddAsync(application);
        CreatedApplicationResponse response = _mapper.Map<CreatedApplicationResponse>(application);
        return new SuccessDataResult<CreatedApplicationResponse>(response, "Added Successfully");
    }

    public async Task<IDataResult<DeletedApplicationResponse>> DeleteAsync(DeleteApplicationRequest request)
    {
        Application application = _mapper.Map<Application>(request);
        await _applicationRepository.DeleteAsync(application);
        DeletedApplicationResponse response = _mapper.Map<DeletedApplicationResponse>(application);
        return new SuccessDataResult<DeletedApplicationResponse>(response, "Deleted Successfully");
    }

    public async Task<IDataResult<List<GetAllApplicationResponse>>> GetAllAsync()
    {
        var list = await _applicationRepository.GetAllAsync();
        List<GetAllApplicationResponse> response = _mapper.Map<List<GetAllApplicationResponse>>(list);
        return new SuccessDataResult<List<GetAllApplicationResponse>>(response, "Listed Successfully");
    }

    public async Task<IDataResult<GetByIdApplicationResponse>> GetByIdAsync(int id)
    {
        var item = await _applicationRepository.GetAsync(x=> x.Id == id);

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
        return new SuccessDataResult<UpdatedApplicationResponse>(response, "Application succesfully updated!");
    }
}
