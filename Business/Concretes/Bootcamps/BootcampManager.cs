using AutoMapper;
using Business.Abstracts.Bootcamps;
using Business.Requests.ApplicationStates;
using Business.Requests.Bootcamps;
using Business.Responses.ApplicationStates;
using Business.Responses.Bootcamps;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using DataAccess.Concretes.Repositories;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes.Bootcamps;

public class BootcampManager:IBootcampService
{
    private readonly IBootcampRepository _bootcampRepository;
    private readonly IMapper _mapper;

    public BootcampManager(IBootcampRepository bootcampRepository, IMapper mapper)
    {
        _bootcampRepository = bootcampRepository;
        _mapper = mapper;
    }

    public async Task<IDataResult<CreatedBootcampResponse>> AddAsync(CreateBootcampRequest request)
    {
        Bootcamp bootcamp = _mapper.Map<Bootcamp>(request);
        await _bootcampRepository.AddAsync(bootcamp);
        CreatedBootcampResponse response = _mapper.Map<CreatedBootcampResponse>(bootcamp);
        return new SuccessDataResult<CreatedBootcampResponse>(response, "Added Successfully");
    }

    public async Task<IDataResult<DeletedBootcampResponse>> DeleteAsync(DeleteBootcampRequest request)
    {
        Bootcamp bootcamp = _mapper.Map<Bootcamp>(request);
        await _bootcampRepository.DeleteAsync(bootcamp);
        DeletedBootcampResponse response = _mapper.Map<DeletedBootcampResponse>(bootcamp);
        return new SuccessDataResult<DeletedBootcampResponse>(response, "Deleted Successfully");
    }

    public async Task<IDataResult<List<GetAllBootcampResponse>>> GetAllAsync()
    {
        var list = await _bootcampRepository.GetAllAsync();
        List<GetAllBootcampResponse> response = _mapper.Map<List<GetAllBootcampResponse>>(list);
        return new SuccessDataResult<List<GetAllBootcampResponse>>(response, "Listed Successfully");
    }

    public async Task<IDataResult<GetByIdBootcampResponse>> GetByIdAsync(int id)
    {
        var item = await _bootcampRepository.GetAsync(x => x.Id == id);

        GetByIdBootcampResponse response = _mapper.Map<GetByIdBootcampResponse>(item);

        if (item != null)
        {
            return new SuccessDataResult<GetByIdBootcampResponse>(response, "Found Succesfully.");
        }
        return new ErrorDataResult<GetByIdBootcampResponse>("Bootcamp could not be found.");
    }

    public async Task<IDataResult<UpdatedBootcampResponse>> UpdateAsync(UpdateBootcampRequest request)
    {
        var item = await _bootcampRepository.GetAsync(p => p.Id == request.Id);
        if (request.Id == 0 || item == null)
        {
            return new ErrorDataResult<UpdatedBootcampResponse>("Bootcamp could not be found.");
        }

        _mapper.Map(request, item);
        await _bootcampRepository.UpdateAsync(item);

        UpdatedBootcampResponse response = _mapper.Map<UpdatedBootcampResponse>(item);
        return new SuccessDataResult<UpdatedBootcampResponse>(response, "Bootcamp succesfully updated!");
    }
}
