using Core.DataAccess;
using Core.Utilities.Security.Entities;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts;

public interface IUserRepository: IAsyncRepository<User, int>, IRepository<User, int>
{
}
