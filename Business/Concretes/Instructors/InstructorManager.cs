using AutoMapper;
using Business.Abstracts.Instructor;
using Business.Constants;
using Business.Requests.Instructor;
using Business.Responses.Instructor;
using Business.Rules;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes;

public class InstructorManager : IInstructorService
{
    private readonly IInstructorRepository _instructorRepository;
    private readonly IMapper _mapper;
    private readonly InstructorBusinessRules _rules;

    public InstructorManager(IInstructorRepository instructorRepository, IMapper mapper, InstructorBusinessRules rules)
    {
        _instructorRepository = instructorRepository;
        _mapper = mapper;
        _rules = rules;
    }
    [LogAspect(typeof(MongoDbLogger))]
    public async Task<IDataResult<CreatedInstructorResponse>> AddAsync(CreateInstructorRequest request)
    {
        await _rules.CheckUserNameIfExist(request.UserName, null);

        Instructor instructor = _mapper.Map<Instructor>(request);
        await _instructorRepository.AddAsync(instructor);
        CreatedInstructorResponse response = _mapper.Map<CreatedInstructorResponse>(instructor);
        return new SuccessDataResult<CreatedInstructorResponse>(response, InstructorMessages.InstructorAdded);
    }
    [LogAspect(typeof(MongoDbLogger))]
    public async Task<IResult> DeleteAsync(DeleteInstructorRequest request)
    {
        await _rules.CheckIdIfNotExist(request.Id);

        var item = await _instructorRepository.GetAsync(x => x.Id == request.Id);
        await _instructorRepository.DeleteAsync(item);

        return new SuccessResult(InstructorMessages.InstructorDeleted);
    }

    public async Task<IDataResult<List<GetAllInstructorResponse>>> GetAllAsync()
    {
        var list = await _instructorRepository.GetAllAsync();
        List<GetAllInstructorResponse> response = _mapper.Map<List<GetAllInstructorResponse>>(list);
        return new SuccessDataResult<List<GetAllInstructorResponse>>(response, InstructorMessages.InstructorListed);
    }

    public async Task<IDataResult<GetByIdInstructorResponse>> GetByIdAsync(int id)
    {
        await _rules.CheckIdIfNotExist(id);

        var item = await _instructorRepository.GetAsync(x => x.Id == id);

        GetByIdInstructorResponse response = _mapper.Map<GetByIdInstructorResponse>(item);


        return new SuccessDataResult<GetByIdInstructorResponse>(response, InstructorMessages.InstructorFound);


    }
    [LogAspect(typeof(MongoDbLogger))]
    public async Task<IDataResult<UpdatedInstructorResponse>> UpdateAsync(UpdateInstructorRequest request)
    {
        await _rules.CheckIdIfNotExist(request.Id);
        await _rules.CheckUserNameIfExist(request.UserName, request.Id);

        var item = await _instructorRepository.GetAsync(p => p.Id == request.Id);

        _mapper.Map(request, item);
        await _instructorRepository.UpdateAsync(item);

        UpdatedInstructorResponse response = _mapper.Map<UpdatedInstructorResponse>(item);
        return new SuccessDataResult<UpdatedInstructorResponse>(response, InstructorMessages.InstructorUpdated);
    }


}
