using AutoMapper;
using Business.Abstracts.Bootcamps;
using Business.Abstracts.BootcampStates;
using Business.Requests.Bootcamps;
using Business.Requests.BootcampStates;
using Business.Responses.Bootcamps;
using Business.Responses.BootcampStates;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes.BootcampStates;

public class BootcampStateManager:IBootcampStateService
{
    private readonly IBootcampStateRepository _bootcampStateRepository;
    private readonly IMapper _mapper;

    public BootcampStateManager(IBootcampStateRepository bootcampStateRepository, IMapper mapper)
    {
        _bootcampStateRepository = bootcampStateRepository;
        _mapper = mapper;
    }

    public async Task<IDataResult<CreatedBootcampStateResponse>> AddAsync(CreateBootcampStateRequest request)
    {
        BootcampState bootcampState = _mapper.Map<BootcampState>(request);
        await _bootcampStateRepository.AddAsync(bootcampState);
        CreatedBootcampStateResponse response = _mapper.Map<CreatedBootcampStateResponse>(bootcampState);
        return new SuccessDataResult<CreatedBootcampStateResponse>(response, "Added Successfully");
    }

    public async Task<IDataResult<DeletedBootcampStateResponse>> DeleteAsync(DeleteBootcampStateRequest request)
    {
        BootcampState bootcampState = _mapper.Map<BootcampState>(request);
        await _bootcampStateRepository.DeleteAsync(bootcampState);
        DeletedBootcampStateResponse response = _mapper.Map<DeletedBootcampStateResponse>(bootcampState);
        return new SuccessDataResult<DeletedBootcampStateResponse>(response, "Deleted Successfully");
    }

    public async Task<IDataResult<List<GetAllBootcampStateResponse>>> GetAllAsync()
    {
        var list = await _bootcampStateRepository.GetAllAsync();
        List<GetAllBootcampStateResponse> response = _mapper.Map<List<GetAllBootcampStateResponse>>(list);
        return new SuccessDataResult<List<GetAllBootcampStateResponse>>(response, "Listed Successfully");
    }

    public async Task<IDataResult<GetByIdBootcampStateResponse>> GetByIdAsync(int id)
    {
        var item = await _bootcampStateRepository.GetAsync(x => x.Id == id);

        GetByIdBootcampStateResponse response = _mapper.Map<GetByIdBootcampStateResponse>(item);

        if (item != null)
        {
            return new SuccessDataResult<GetByIdBootcampStateResponse>(response, "Found Succesfully.");
        }
        return new ErrorDataResult<GetByIdBootcampStateResponse>("BootcampState could not be found.");
    }

    public async Task<IDataResult<UpdatedBootcampStateResponse>> UpdateAsync(UpdateBootcampStateRequest request)
    {
        var item = await _bootcampStateRepository.GetAsync(p => p.Id == request.Id);
        if (request.Id == 0 || item == null)
        {
            return new ErrorDataResult<UpdatedBootcampStateResponse>("BootcampState could not be found.");
        }

        _mapper.Map(request, item);
        await _bootcampStateRepository.UpdateAsync(item);

        UpdatedBootcampStateResponse response = _mapper.Map<UpdatedBootcampStateResponse>(item);
        return new SuccessDataResult<UpdatedBootcampStateResponse>(response, "BootcampState succesfully updated!");
    }
}
