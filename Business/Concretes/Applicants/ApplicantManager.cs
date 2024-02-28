using AutoMapper;
using Business.Abstracts;
using Business.Requests.Applicant;
using Business.Responses.Applicant;
using Core.Exceptions.Types;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstracts;
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
        await CheckUserNameIfExist(request.UserName, null);

        Applicant applicant = _mapper.Map<Applicant>(request);
        await _applicantRepository.AddAsync(applicant);
        CreatedApplicantResponse response = _mapper.Map<CreatedApplicantResponse>(applicant);
        return new SuccessDataResult<CreatedApplicantResponse>(response, "Added Successfully");
    }

    public async Task<IResult> DeleteAsync(DeleteApplicantRequest request)
    {
        await CheckIdIfNotExist(request.Id);

        var item = await _applicantRepository.GetAsync(p => p.Id == request.Id);
        await _applicantRepository.DeleteAsync(item);
        return new SuccessResult("Deleted Successfully");
    }

    public async Task<IDataResult<List<GetAllApplicantResponse>>> GetAllAsync()
    {
        var list = await _applicantRepository.GetAllAsync();
        List<GetAllApplicantResponse> response = _mapper.Map<List<GetAllApplicantResponse>>(list);
        return new SuccessDataResult<List<GetAllApplicantResponse>>(response, "Listed Successfully");
    }

    public async Task<IDataResult<GetByIdApplicantResponse>> GetByIdAsync(int id)
    {
        await CheckIdIfNotExist(id);

        var item = await _applicantRepository.GetAsync(x => x.Id == id);

        GetByIdApplicantResponse response = _mapper.Map<GetByIdApplicantResponse>(item);

        return new SuccessDataResult<GetByIdApplicantResponse>(response, "Found Succesfully.");

    }

    public async Task<IDataResult<UpdatedApplicantResponse>> UpdateAsync(UpdateApplicantRequest request)
    {
        await CheckIdIfNotExist(request.Id);
        await CheckUserNameIfExist(request.UserName, request.Id);

        var item = await _applicantRepository.GetAsync(p => p.Id == request.Id);

        _mapper.Map(request, item);
        await _applicantRepository.UpdateAsync(item);

        UpdatedApplicantResponse response = _mapper.Map<UpdatedApplicantResponse>(item);
        return new SuccessDataResult<UpdatedApplicantResponse>(response, "Applicant updated successfully!");
    }

    public async Task CheckUserNameIfExist(string userName, int? id)
    {
       
        var item = await _applicantRepository.GetAsync(x => x.UserName == SeoHelper.ToSeoUrl(userName) && x.Id != id); 
        if (item != null)
        {
            throw new BusinessException("Username already exist");
        }
    }

    public async Task CheckIdIfNotExist(int id)
    {
        var item = await _applicantRepository.GetAsync(x => x.Id == id);
        if (item == null)
        {
            throw new BusinessException("ID could not be found.");
        }

    }
}
