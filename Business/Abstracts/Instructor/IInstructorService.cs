using Business.Requests.Employee;
using Business.Requests.Instructor;
using Business.Responses.Employee;
using Business.Responses.Instructor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts.Instructor;

public interface IInstructorService
{
    Task<CreatedInstructorResponse> AddAsync(CreateInstructorRequest request);
    Task<UpdatedInstructorResponse> UpdateAsync(UpdateInstructorRequest request);
    Task<DeletedInstructorResponse> DeleteAsync(DeleteInstructorRequest request);
    Task<List<GetAllInstructorResponse>> GetAllAsync();
    Task<GetByIdInstructorResponse> GetByIdAsync(int id);
}
