using AutoMapper;
using Business.Abstracts;
using Business.Requests.Applicant;
using Business.Responses.Applicant;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using Business.Rules;
using Business.Constants;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;

namespace Business.Concretes;

public class ApplicantManager : IApplicantService
{
    private readonly IApplicantRepository _applicantRepository;
    private readonly IMapper _mapper;
    private readonly ApplicantBusinessRules _rules;

    public ApplicantManager(IApplicantRepository applicantRepository, IMapper mapper, ApplicantBusinessRules rules)
    {
        _applicantRepository = applicantRepository;
        _mapper = mapper;
        _rules = rules;
    }
    [LogAspect(typeof(MongoDbLogger))]
    public async Task<IDataResult<CreatedApplicantResponse>> AddAsync(CreateApplicantRequest request)
    {
        await _rules.CheckUserNameIfExist(request.UserName, null);

        Applicant applicant = _mapper.Map<Applicant>(request);
        await _applicantRepository.AddAsync(applicant);
        CreatedApplicantResponse response = _mapper.Map<CreatedApplicantResponse>(applicant);
        return new SuccessDataResult<CreatedApplicantResponse>(response, ApplicantMessages.ApplicantAdded);
    }
    [LogAspect(typeof(MongoDbLogger))]
    public async Task<IResult> DeleteAsync(DeleteApplicantRequest request)
    {
        await _rules.CheckIdIfNotExist(request.Id);

        var item = await _applicantRepository.GetAsync(p => p.Id == request.Id);
        await _applicantRepository.DeleteAsync(item);
        return new SuccessResult(ApplicantMessages.ApplicantDeleted);
    }

    public async Task<IDataResult<List<GetAllApplicantResponse>>> GetAllAsync()
    {
        var list = await _applicantRepository.GetAllAsync();
        List<GetAllApplicantResponse> response = _mapper.Map<List<GetAllApplicantResponse>>(list);
        return new SuccessDataResult<List<GetAllApplicantResponse>>(response, ApplicantMessages.ApplicantListed);
    }

    public async Task<IDataResult<GetByIdApplicantResponse>> GetByIdAsync(int id)
    {
        await _rules.CheckIdIfNotExist(id);

        var item = await _applicantRepository.GetAsync(x => x.Id == id);

        GetByIdApplicantResponse response = _mapper.Map<GetByIdApplicantResponse>(item);

        return new SuccessDataResult<GetByIdApplicantResponse>(response, ApplicantMessages.ApplicantFound);

    }
    [LogAspect(typeof(MongoDbLogger))]
    public async Task<IDataResult<UpdatedApplicantResponse>> UpdateAsync(UpdateApplicantRequest request)
    {
        await _rules.CheckIdIfNotExist(request.Id);
        await _rules.CheckUserNameIfExist(request.UserName, request.Id);

        var item = await _applicantRepository.GetAsync(p => p.Id == request.Id);

        _mapper.Map(request, item);
        await _applicantRepository.UpdateAsync(item);

        UpdatedApplicantResponse response = _mapper.Map<UpdatedApplicantResponse>(item);
        return new SuccessDataResult<UpdatedApplicantResponse>(response, ApplicantMessages.ApplicantUpdated);
    }

    
}
