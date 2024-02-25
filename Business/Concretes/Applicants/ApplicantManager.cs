using AutoMapper;
using Business.Abstracts;
using Business.Requests.Applicant;
using Business.Responses.Applicant;
using Business.Responses.Applications;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using DataAccess.Concretes.Repositories;
using Entities.Concretes;

namespace Business.Concretes;

public class ApplicantManager : IApplicantService
{
    private readonly IApplicantRepository _applicantRepository;
    private readonly IMapper _mapper;
    public ApplicantManager(IApplicantRepository applicantRepository, IMapper mapper)
    {
        _applicantRepository = applicantRepository;
        _mapper = mapper;
    }

    public async Task<IDataResult<CreatedApplicantResponse>> AddAsync(CreateApplicantRequest request)
    {
        Applicant applicant = _mapper.Map<Applicant>(request);
        await _applicantRepository.AddAsync(applicant);
        CreatedApplicantResponse response = _mapper.Map<CreatedApplicantResponse>(applicant);
        return new SuccessDataResult<CreatedApplicantResponse>(response, "Added Successfully");
    }

    public async Task<IDataResult<DeletedApplicantResponse>> DeleteAsync(DeleteApplicantRequest request)
    {
        Applicant applicant = _mapper.Map<Applicant>(request);
        await _applicantRepository.DeleteAsync(applicant);
        DeletedApplicantResponse response = _mapper.Map<DeletedApplicantResponse>(applicant);
        return new SuccessDataResult<DeletedApplicantResponse>(response, "Deleted Successfully");
    }

    public async Task<IDataResult<List<GetAllApplicantResponse>>> GetAllAsync()
    {
        var list = await _applicantRepository.GetAllAsync();
        List<GetAllApplicantResponse> response = _mapper.Map<List<GetAllApplicantResponse>>(list);
        return new SuccessDataResult<List<GetAllApplicantResponse>>(response, "Listed Successfully");
    }

    public async Task<IDataResult<GetByIdApplicantResponse>> GetByIdAsync(int id)
    {
        var item = await _applicantRepository.GetAsync(x => x.Id == id);

        GetByIdApplicantResponse response = _mapper.Map<GetByIdApplicantResponse>(item);

        if (item != null)
        {
            return new SuccessDataResult<GetByIdApplicantResponse>(response, "Found Succesfully.");
        }
        return new ErrorDataResult<GetByIdApplicantResponse>("Applicant could not be found.");
    }

    public async Task<IDataResult<UpdatedApplicantResponse>> UpdateAsync(UpdateApplicantRequest request)
    {
        var item = await _applicantRepository.GetAsync(p => p.Id == request.Id);
        if (request.Id == 0 || item == null)
        {
            return new ErrorDataResult<UpdatedApplicantResponse>("Applicant could not be found.");
        }

        _mapper.Map(request, item);
        await _applicantRepository.UpdateAsync(item);

        UpdatedApplicantResponse response = _mapper.Map<UpdatedApplicantResponse>(item);
        return new SuccessDataResult<UpdatedApplicantResponse>(response, "Applicant updated successfully!");
    }
}
