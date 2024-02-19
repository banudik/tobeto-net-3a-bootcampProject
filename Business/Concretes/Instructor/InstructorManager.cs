using Business.Abstracts.Instructor;
using Business.Requests.Instructor;
using Business.Responses.Applicant;
using Business.Responses.Instructor;
using DataAccess.Abstracts;
using DataAccess.Concretes.Repositories;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        instructorToCreate.CompanyName = request.CompanyName;
        await _instructorRepository.Add(instructorToCreate);

        CreatedInstructorResponse response = new CreatedInstructorResponse();
        response.CompanyName = instructorToCreate.CompanyName;
        return response;
    }

    public async Task<DeletedInstructorResponse> DeleteAsync(DeleteInstructorRequest request)
    {
        Instructor instructorToDelete = new Instructor();
        instructorToDelete.Id = request.Id;
        await _instructorRepository.Delete(instructorToDelete);

        DeletedInstructorResponse response = new DeletedInstructorResponse();
        response.Id = instructorToDelete.Id;
        return response;
    }

    public async Task<List<GetAllInstructorResponse>> GetAllAsync()
    {
        List<GetAllInstructorResponse> instructors = new List<GetAllInstructorResponse>();
        foreach (var instructor in await _instructorRepository.GetAll())
        {
            GetAllInstructorResponse response = new GetAllInstructorResponse();
            response.Id = instructor.Id;
            response.CompanyName =instructor.CompanyName;
            instructors.Add(response);
        }
        return instructors;
    }

    public async Task<GetByIdInstructorResponse> GetByIdAsync(int id)
    {
        GetByIdInstructorResponse response = new GetByIdInstructorResponse();
        Instructor instructor = await _instructorRepository.Get(x => x.Id == id);
        response.Id = instructor.Id;
        response.CompanyName = instructor.CompanyName;
        return response;
    }

    public async Task<UpdatedInstructorResponse> UpdateAsync(UpdateInstructorRequest request)
    {
        Instructor instructorToUpdate = await _instructorRepository.Get(x => x.Id == request.Id);
        instructorToUpdate.Id = request.Id;
        instructorToUpdate.CompanyName = request.CompanyName;
        await _instructorRepository.Update(instructorToUpdate);

        UpdatedInstructorResponse response = new UpdatedInstructorResponse();
        response.Id = instructorToUpdate.Id;
        response.CompanyName=instructorToUpdate.CompanyName;
        return response;
       
       
    }
}
