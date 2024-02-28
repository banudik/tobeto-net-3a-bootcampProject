using Business.Requests.Employee;
using Business.Responses.Employee;
using Core.Utilities.Results;

namespace Business.Abstracts.Employee;

public interface IEmployeeService
{
    Task<IDataResult<CreatedEmployeeResponse>> AddAsync(CreateEmployeeRequest request);
    Task<IDataResult<UpdatedEmployeeResponse>> UpdateAsync(UpdateEmployeeRequest request);
    Task<IResult> DeleteAsync(DeleteEmployeeRequest request);
    Task<IDataResult<List<GetAllEmployeeResponse>>> GetAllAsync();
    Task<IDataResult<GetByIdEmployeeResponse>> GetByIdAsync(int id);
}
