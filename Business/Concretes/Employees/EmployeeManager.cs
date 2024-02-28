using AutoMapper;
using Business.Abstracts.Employee;
using Business.Requests.Applications;
using Business.Requests.Employee;
using Business.Responses.Applications;
using Business.Responses.Employee;
using Core.Exceptions.Types;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using DataAccess.Concretes.Repositories;
using Entities.Concretes;

namespace Business.Concretes;

public class EmployeeManager : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IMapper _mapper;
    public EmployeeManager(IEmployeeRepository employeeRepository, IMapper mapper)
    {
        _employeeRepository = employeeRepository;
        _mapper = mapper;
    }

    public async Task<IDataResult<CreatedEmployeeResponse>> AddAsync(CreateEmployeeRequest request)
    {
        await CheckUserNameIfExist(request.UserName, null);

        Employee employee = _mapper.Map<Employee>(request);
        await _employeeRepository.AddAsync(employee);
        CreatedEmployeeResponse response = _mapper.Map<CreatedEmployeeResponse>(employee);
        return new SuccessDataResult<CreatedEmployeeResponse>(response, "Added Successfully");
    }

    public async Task<IResult> DeleteAsync(DeleteEmployeeRequest request)
    {
        await CheckIdIfNotExist(request.Id);

        var item = await _employeeRepository.GetAsync(x=>x.Id == request.Id);
        await _employeeRepository.DeleteAsync(item);
        
        return new SuccessResult("Deleted Successfully");
    }

    public async Task<IDataResult<List<GetAllEmployeeResponse>>> GetAllAsync()
    {
        var list = await _employeeRepository.GetAllAsync();
        List<GetAllEmployeeResponse> response = _mapper.Map<List<GetAllEmployeeResponse>>(list);
        return new SuccessDataResult<List<GetAllEmployeeResponse>>(response, "Listed Successfully");
    }

    public async Task<IDataResult<GetByIdEmployeeResponse>> GetByIdAsync(int id)
    {
        await CheckIdIfNotExist(id);

        var item = await _employeeRepository.GetAsync(x => x.Id == id);

        GetByIdEmployeeResponse response = _mapper.Map<GetByIdEmployeeResponse>(item);

            return new SuccessDataResult<GetByIdEmployeeResponse>(response, "Found Succesfully.");
       
        
    }

    public async Task<IDataResult<UpdatedEmployeeResponse>> UpdateAsync(UpdateEmployeeRequest request)
    {
        await CheckIdIfNotExist(request.Id);
        await CheckUserNameIfExist(request.UserName, request.Id);

        var item = await _employeeRepository.GetAsync(p => p.Id == request.Id);

        _mapper.Map(request, item);
        await _employeeRepository.UpdateAsync(item);

        UpdatedEmployeeResponse response = _mapper.Map<UpdatedEmployeeResponse>(item);
        return new SuccessDataResult<UpdatedEmployeeResponse>(response, "Employee updated successfully!");
    }
    public async Task CheckUserNameIfExist(string userName, int? id)
    {

        var item = await _employeeRepository.GetAsync(x => x.UserName == SeoHelper.ToSeoUrl(userName) && x.Id != id);
        if (item != null)
        {
            throw new BusinessException("Username already exist");
        }
    }

    public async Task CheckIdIfNotExist(int id)
    {
        var item = await _employeeRepository.GetAsync(x => x.Id == id);
        if (item == null)
        {
            throw new NotFoundException("ID could not be found.");
        }
    }
}
