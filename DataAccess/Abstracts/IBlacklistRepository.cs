using Core.DataAccess;
using Entities.Concretes;

namespace DataAccess.Abstracts;

public interface IBlacklistRepository:IAsyncRepository<Blacklist, int>, IRepository<Blacklist, int>
{
}
