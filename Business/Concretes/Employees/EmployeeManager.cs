using AutoMapper;
using Business.Abstracts.Employee;
using Business.Requests.Applications;
using Business.Requests.Employee;
using Business.Responses.Applications;
using Business.Responses.Employee;
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
        Employee employee = _mapper.Map<Employee>(request);
        await _employeeRepository.AddAsync(employee);
        CreatedEmployeeResponse response = _mapper.Map<CreatedEmployeeResponse>(employee);
        return new SuccessDataResult<CreatedEmployeeResponse>(response, "Added Successfully");
    }

    public async Task<IDataResult<DeletedEmployeeResponse>> DeleteAsync(DeleteEmployeeRequest request)
    {
        Employee employee = _mapper.Map<Employee>(request);
        await _employeeRepository.DeleteAsync(employee);
        DeletedEmployeeResponse response = _mapper.Map<DeletedEmployeeResponse>(employee);
        return new SuccessDataResult<DeletedEmployeeResponse>(response, "Deleted Successfully");
    }

    public async Task<IDataResult<List<GetAllEmployeeResponse>>> GetAllAsync()
    {
        var list = await _employeeRepository.GetAllAsync();
        List<GetAllEmployeeResponse> response = _mapper.Map<List<GetAllEmployeeResponse>>(list);
        return new SuccessDataResult<List<GetAllEmployeeResponse>>(response, "Listed Successfully");
    }

    public async Task<IDataResult<GetByIdEmployeeResponse>> GetByIdAsync(int id)
    {
        var item = await _employeeRepository.GetAsync(x => x.Id == id);

        GetByIdEmployeeResponse response = _mapper.Map<GetByIdEmployeeResponse>(item);

        if (item != null)
        {
            return new SuccessDataResult<GetByIdEmployeeResponse>(response, "Found Succesfully.");
        }
        return new ErrorDataResult<GetByIdEmployeeResponse>("Employee could not be found.");
    }

    public async Task<IDataResult<UpdatedEmployeeResponse>> UpdateAsync(UpdateEmployeeRequest request)
    {
        var item = await _employeeRepository.GetAsync(p => p.Id == request.Id);
        if (request.Id == 0 || item == null)
        {
            return new ErrorDataResult<UpdatedEmployeeResponse>("Employee could not be found.");
        }

        _mapper.Map(request, item);
        await _employeeRepository.UpdateAsync(item);

        UpdatedEmployeeResponse response = _mapper.Map<UpdatedEmployeeResponse>(item);
        return new SuccessDataResult<UpdatedEmployeeResponse>(response, "Employee updated successfully!");
    }
}
