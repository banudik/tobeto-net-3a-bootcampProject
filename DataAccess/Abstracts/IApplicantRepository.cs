using Core.DataAccess;
using Entities.Concretes;

namespace DataAccess.Abstracts;

public interface IApplicantRepository : IAsyncRepository<Applicant, int>, IRepository<Applicant, int>
{
    
}
