using Business.Abstracts.Employee;
using Business.Requests.Employee;
using Business.Responses.Employee;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes;

public class EmployeeManager : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeManager(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<CreatedEmployeeResponse> AddAsync(CreateEmployeeRequest request)
    {
        Employee employeeToCreate = new Employee();
        employeeToCreate.Position = request.Position;
        await _employeeRepository.Add(employeeToCreate);

        CreatedEmployeeResponse response = new CreatedEmployeeResponse();
        response.Position = request.Position;
        return response;
    }

    public async Task<DeletedEmployeeResponse> DeleteAsync(DeleteEmployeeRequest request)
    {
        Employee employeeToDelete = new Employee();
        employeeToDelete.Id = request.Id;
        await _employeeRepository.Delete(employeeToDelete);

        DeletedEmployeeResponse response = new DeletedEmployeeResponse();
        response.Id = employeeToDelete.Id;
        return response;
    }

    public async Task<List<GetAllEmployeeResponse>> GetAllAsync()
    {
        List<GetAllEmployeeResponse> employees = new List<GetAllEmployeeResponse>();
        foreach (var employee in await _employeeRepository.GetAll())
        {
            GetAllEmployeeResponse response = new GetAllEmployeeResponse();
            response.Id = employee.Id;
            response.Position = employee.Position;
            employees.Add(response);
        }
        return employees;
    }

    public async Task<GetByIdEmployeeResponse> GetByIdAsync(int id)
    {
        GetByIdEmployeeResponse response = new GetByIdEmployeeResponse();
        Employee employee = await _employeeRepository.Get(x=> x.Id == id);
        response.Id = employee.Id;
        response.Position = employee.Position;
        return response;
    }

    public async Task<UpdatedEmployeeResponse> UpdateAsync(UpdateEmployeeRequest request)
    {
        Employee employeeToUpdate = await _employeeRepository.Get(x => x.Id == request.Id);
        employeeToUpdate.Id = request.Id;
        employeeToUpdate.Position = request.Position;
        await _employeeRepository.Update(employeeToUpdate);

        UpdatedEmployeeResponse response = new UpdatedEmployeeResponse();
        response.Id = employeeToUpdate.Id;
        response.Position = employeeToUpdate.Position;
        return response;
    }
}
