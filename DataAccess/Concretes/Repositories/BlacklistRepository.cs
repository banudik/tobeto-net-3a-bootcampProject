using Core.DataAccess.EntityFramework;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes.Repositories;

public class BlacklistRepository : EfRepositoryBase<Blacklist, int, BaseDbContext>, IBlacklistRepository
{
    public BlacklistRepository(BaseDbContext context) : base(context)
    {
    }
}
