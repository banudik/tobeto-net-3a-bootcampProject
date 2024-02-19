using Business.Requests.Applicant;
using Business.Requests.Employee;
using Business.Responses.Applicant;
using Business.Responses.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts.Employee;

public interface IEmployeeService
{
    Task<CreatedEmployeeResponse> AddAsync(CreateEmployeeRequest request);
    Task<UpdatedEmployeeResponse> UpdateAsync(UpdateEmployeeRequest request);
    Task<DeletedEmployeeResponse> DeleteAsync(DeleteEmployeeRequest request);
    Task<List<GetAllEmployeeResponse>> GetAllAsync();
    Task<GetByIdEmployeeResponse> GetByIdAsync(int id);
}
