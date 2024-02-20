using Business.Abstracts.Instructor;
using Business.Requests.Instructor;
using Business.Responses.Instructor;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes;

public class InstructorManager : IInstructorService
{
    private readonly IInstructorRepository _instructorRepository;

    public InstructorManager(IInstructorRepository instructorRepository)
    {
        _instructorRepository = instructorRepository;
    }

    public async Task<CreatedInstructorResponse> AddAsync(CreateInstructorRequest request)
    {
        Instructor instructorToCreate = new Instructor();
        instructorToCreate.UserName = request.UserName;
        instructorToCreate.FirstName = request.FirstName;
        instructorToCreate.LastName = request.LastName;
        instructorToCreate.DateOfBirth = request.DateOfBirth;
        instructorToCreate.NationalIdentity = request.NationalIdentity;
        instructorToCreate.Email = request.Email;
        instructorToCreate.Password = request.Password;
        instructorToCreate.CompanyName = request.CompanyName;
        await _instructorRepository.AddAsync(instructorToCreate);

        CreatedInstructorResponse response = new CreatedInstructorResponse();
        response.UserName = instructorToCreate.UserName;
        response.FirstName = instructorToCreate.FirstName;
        response.LastName = instructorToCreate.LastName;
        response.DateOfBirth = instructorToCreate.DateOfBirth;
        response.NationalIdentity = instructorToCreate.NationalIdentity;
        response.Email = instructorToCreate.Email;
        response.Password = instructorToCreate.Password;
        response.CompanyName = instructorToCreate.CompanyName;
        return response;
    }

    public async Task<DeletedInstructorResponse> DeleteAsync(DeleteInstructorRequest request)
    {
        Instructor instructorToDelete = new Instructor();
        instructorToDelete.Id = request.Id;
        await _instructorRepository.DeleteAsync(instructorToDelete);

        DeletedInstructorResponse response = new DeletedInstructorResponse();
        response.Id = instructorToDelete.Id;
        return response;
    }

    public async Task<List<GetAllInstructorResponse>> GetAllAsync()
    {
        List<GetAllInstructorResponse> instructors = new List<GetAllInstructorResponse>();
        foreach (var instructor in await _instructorRepository.GetAllAsync())
        {
            GetAllInstructorResponse response = new GetAllInstructorResponse();
            response.Id = instructor.Id;
            response.UserName = instructor.UserName;
            response.FirstName = instructor.FirstName;
            response.LastName = instructor.LastName;
            response.DateOfBirth = instructor.DateOfBirth;
            response.NationalIdentity = instructor.NationalIdentity;
            response.Email = instructor.Email;
            response.Password = instructor.Password;
            response.CompanyName =instructor.CompanyName;
            instructors.Add(response);
        }
        return instructors;
    }

    public async Task<GetByIdInstructorResponse> GetByIdAsync(int id)
    {
        GetByIdInstructorResponse response = new GetByIdInstructorResponse();
        Instructor instructor = await _instructorRepository.GetAsync(x => x.Id == id);
        response.Id = instructor.Id;
        response.UserName = instructor.UserName;
        response.FirstName = instructor.FirstName;
        response.LastName = instructor.LastName;
        response.DateOfBirth = instructor.DateOfBirth;
        response.NationalIdentity = instructor.NationalIdentity;
        response.Email = instructor.Email;
        response.Password = instructor.Password;
        response.CompanyName = instructor.CompanyName;
        return response;
    }

    public async Task<UpdatedInstructorResponse> UpdateAsync(UpdateInstructorRequest request)
    {
        Instructor instructorToUpdate = await _instructorRepository.GetAsync(x => x.Id == request.Id);
        instructorToUpdate.Id = request.Id;
        instructorToUpdate.UserName = request.UserName;
        instructorToUpdate.FirstName = request.FirstName;
        instructorToUpdate.LastName = request.LastName;
        instructorToUpdate.DateOfBirth = request.DateOfBirth;
        instructorToUpdate.NationalIdentity = request.NationalIdentity;
        instructorToUpdate.Email = request.Email;
        instructorToUpdate.Password = request.Password;
        instructorToUpdate.CompanyName = request.CompanyName;
        await _instructorRepository.UpdateAsync(instructorToUpdate);

        UpdatedInstructorResponse response = new UpdatedInstructorResponse();
        response.Id = instructorToUpdate.Id;
        response.UserName = instructorToUpdate.UserName;
        response.FirstName = instructorToUpdate.FirstName;
        response.LastName = instructorToUpdate.LastName;
        response.DateOfBirth = instructorToUpdate.DateOfBirth;
        response.NationalIdentity = instructorToUpdate.NationalIdentity;
        response.Email = instructorToUpdate.Email;
        response.Password = instructorToUpdate.Password;
        response.CompanyName=instructorToUpdate.CompanyName;
        return response;
       
       
    }
}
