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
        employeeToCreate.UserName = request.UserName;
        employeeToCreate.FirstName = request.FirstName;
        employeeToCreate.LastName = request.LastName;
        employeeToCreate.DateOfBirth = request.DateOfBirth;
        employeeToCreate.NationalIdentity = request.NationalIdentity;
        employeeToCreate.Email = request.Email;
        employeeToCreate.Password = request.Password;
        employeeToCreate.Position = request.Position;
        await _employeeRepository.AddAsync(employeeToCreate);

        CreatedEmployeeResponse response = new CreatedEmployeeResponse();
        response.UserName = employeeToCreate.UserName;
        response.FirstName = employeeToCreate.FirstName;
        response.LastName = employeeToCreate.LastName;
        response.DateOfBirth = employeeToCreate.DateOfBirth;
        response.NationalIdentity = employeeToCreate.NationalIdentity;
        response.Email = employeeToCreate.Email;
        response.Password = employeeToCreate.Password;
        response.Position = employeeToCreate.Position;
        return response;
    }

    public async Task<DeletedEmployeeResponse> DeleteAsync(DeleteEmployeeRequest request)
    {
        Employee employeeToDelete = new Employee();
        employeeToDelete.Id = request.Id;
        await _employeeRepository.DeleteAsync(employeeToDelete);

        DeletedEmployeeResponse response = new DeletedEmployeeResponse();
        response.Id = employeeToDelete.Id;
        return response;
    }

    public async Task<List<GetAllEmployeeResponse>> GetAllAsync()
    {
        List<GetAllEmployeeResponse> employees = new List<GetAllEmployeeResponse>();
        foreach (var employee in await _employeeRepository.GetAllAsync())
        {
            GetAllEmployeeResponse response = new GetAllEmployeeResponse();
            response.Id = employee.Id;
            response.UserName = employee.UserName;
            response.FirstName = employee.FirstName;
            response.LastName = employee.LastName;
            response.DateOfBirth = employee.DateOfBirth;
            response.NationalIdentity = employee.NationalIdentity;
            response.Email = employee.Email;
            response.Password = employee.Password;
            response.Position = employee.Position;
            employees.Add(response);
        }
        return employees;
    }

    public async Task<GetByIdEmployeeResponse> GetByIdAsync(int id)
    {
        GetByIdEmployeeResponse response = new GetByIdEmployeeResponse();
        Employee employee = await _employeeRepository.GetAsync(x=> x.Id == id);
        response.Id = employee.Id;
        response.UserName = employee.UserName;
        response.FirstName = employee.FirstName;
        response.LastName = employee.LastName;
        response.DateOfBirth = employee.DateOfBirth;
        response.NationalIdentity = employee.NationalIdentity;
        response.Email = employee.Email;
        response.Password = employee.Password;
        response.Position = employee.Position;
        return response;
    }

    public async Task<UpdatedEmployeeResponse> UpdateAsync(UpdateEmployeeRequest request)
    {
        Employee employeeToUpdate = await _employeeRepository.GetAsync(x => x.Id == request.Id);
        employeeToUpdate.Id = request.Id;
        employeeToUpdate.FirstName = request.FirstName;
        employeeToUpdate.LastName = request.LastName;
        employeeToUpdate.DateOfBirth = request.DateOfBirth;
        employeeToUpdate.NationalIdentity = request.NationalIdentity;
        employeeToUpdate.Email = request.Email;
        employeeToUpdate.Password = request.Password;
        employeeToUpdate.Position = request.Position;
        await _employeeRepository.UpdateAsync(employeeToUpdate);

        UpdatedEmployeeResponse response = new UpdatedEmployeeResponse();
        response.Id = employeeToUpdate.Id;
        response.FirstName = employeeToUpdate.FirstName;
        response.LastName = employeeToUpdate.LastName;
        response.DateOfBirth = employeeToUpdate.DateOfBirth;
        response.NationalIdentity = employeeToUpdate.NationalIdentity;
        response.Email = employeeToUpdate.Email;
        response.Password = employeeToUpdate.Password;
        response.Position = employeeToUpdate.Position;
        return response;
    }
}
