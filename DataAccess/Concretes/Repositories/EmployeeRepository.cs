using Core.DataAccess.EntityFramework;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes.Repositories;

public class EmployeeRepository : EfRepositoryBase<Employee, int, BaseDbContext>, IEmployeeRepository
{
    public EmployeeRepository(BaseDbContext context) : base(context)
    {

    }
}
