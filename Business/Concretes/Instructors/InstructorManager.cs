using AutoMapper;
using Business.Abstracts.Instructor;
using Business.Requests.Employee;
using Business.Requests.Instructor;
using Business.Responses.Employee;
using Business.Responses.Instructor;
using Core.Exceptions.Types;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using DataAccess.Concretes.Repositories;
using Entities.Concretes;

namespace Business.Concretes;

public class InstructorManager : IInstructorService
{
    private readonly IInstructorRepository _instructorRepository;
    private readonly IMapper _mapper;
    public InstructorManager(IInstructorRepository instructorRepository, IMapper mapper)
    {
        _instructorRepository = instructorRepository;
        _mapper = mapper;
    }

    public async Task<IDataResult<CreatedInstructorResponse>> AddAsync(CreateInstructorRequest request)
    {
        await CheckUserNameIfExist(request.UserName, null);

        Instructor instructor = _mapper.Map<Instructor>(request);
        await _instructorRepository.AddAsync(instructor);
        CreatedInstructorResponse response = _mapper.Map<CreatedInstructorResponse>(instructor);
        return new SuccessDataResult<CreatedInstructorResponse>(response, "Added Successfully");
    }

    public async Task<IResult> DeleteAsync(DeleteInstructorRequest request)
    {
        await CheckIdIfNotExist(request.Id);

        var item = await _instructorRepository.GetAsync(x => x.Id == request.Id);
        await _instructorRepository.DeleteAsync(item);
        
        return new SuccessResult("Deleted Successfully");
    }

    public async Task<IDataResult<List<GetAllInstructorResponse>>> GetAllAsync()
    {
        var list = await _instructorRepository.GetAllAsync();
        List<GetAllInstructorResponse> response = _mapper.Map<List<GetAllInstructorResponse>>(list);
        return new SuccessDataResult<List<GetAllInstructorResponse>>(response, "Listed Successfully");
    }

    public async Task<IDataResult<GetByIdInstructorResponse>> GetByIdAsync(int id)
    {
        await CheckIdIfNotExist(id);

        var item = await _instructorRepository.GetAsync(x => x.Id == id);

        GetByIdInstructorResponse response = _mapper.Map<GetByIdInstructorResponse>(item);

        if (item != null)
        {
            return new SuccessDataResult<GetByIdInstructorResponse>(response, "Found Succesfully.");
        }
        return new ErrorDataResult<GetByIdInstructorResponse>("Instructor could not be found.");
    }

    public async Task<IDataResult<UpdatedInstructorResponse>> UpdateAsync(UpdateInstructorRequest request)
    {
        await CheckIdIfNotExist(request.Id);
        await CheckUserNameIfExist(request.UserName, request.Id);

        var item = await _instructorRepository.GetAsync(p => p.Id == request.Id);

        _mapper.Map(request, item);
        await _instructorRepository.UpdateAsync(item);

        UpdatedInstructorResponse response = _mapper.Map<UpdatedInstructorResponse>(item);
        return new SuccessDataResult<UpdatedInstructorResponse>(response, "Instructor updated successfully!");
    }

    public async Task CheckUserNameIfExist(string userName, int? id)
    {

        var item = await _instructorRepository.GetAsync(x => x.UserName == SeoHelper.ToSeoUrl(userName) && x.Id != id);
        if (item != null)
        {
            throw new BusinessException("Username already exist");
        }
    }

    public async Task CheckIdIfNotExist(int id)
    {
        var item = await _instructorRepository.GetAsync(x => x.Id == id);
        if (item == null)
        {
            throw new NotFoundException("ID could not be found.");
        }
    }
}
