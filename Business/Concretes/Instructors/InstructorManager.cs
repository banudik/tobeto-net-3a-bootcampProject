using AutoMapper;
using Business.Abstracts.Instructor;
using Business.Requests.Employee;
using Business.Requests.Instructor;
using Business.Responses.Employee;
using Business.Responses.Instructor;
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
        Instructor instructor = _mapper.Map<Instructor>(request);
        await _instructorRepository.AddAsync(instructor);
        CreatedInstructorResponse response = _mapper.Map<CreatedInstructorResponse>(instructor);
        return new SuccessDataResult<CreatedInstructorResponse>(response, "Added Successfully");
    }

    public async Task<IDataResult<DeletedInstructorResponse>> DeleteAsync(DeleteInstructorRequest request)
    {
        Instructor instructor = _mapper.Map<Instructor>(request);
        await _instructorRepository.DeleteAsync(instructor);
        DeletedInstructorResponse response = _mapper.Map<DeletedInstructorResponse>(instructor);
        return new SuccessDataResult<DeletedInstructorResponse>(response, "Deleted Successfully");
    }

    public async Task<IDataResult<List<GetAllInstructorResponse>>> GetAllAsync()
    {
        var list = await _instructorRepository.GetAllAsync();
        List<GetAllInstructorResponse> response = _mapper.Map<List<GetAllInstructorResponse>>(list);
        return new SuccessDataResult<List<GetAllInstructorResponse>>(response, "Listed Successfully");
    }

    public async Task<IDataResult<GetByIdInstructorResponse>> GetByIdAsync(int id)
    {
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
        var item = await _instructorRepository.GetAsync(p => p.Id == request.Id);
        if (request.Id == 0 || item == null)
        {
            return new ErrorDataResult<UpdatedInstructorResponse>("Instructor could not be found.");
        }

        _mapper.Map(request, item);
        await _instructorRepository.UpdateAsync(item);

        UpdatedInstructorResponse response = _mapper.Map<UpdatedInstructorResponse>(item);
        return new SuccessDataResult<UpdatedInstructorResponse>(response, "Instructor updated successfully!");
    }
}
