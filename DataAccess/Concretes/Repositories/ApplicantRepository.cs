using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework.Contexts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.Repositories;

public class ApplicantRepository : EfRepositoryBase<Applicant, int, BaseDbContext>, IApplicantRepository
{
    public ApplicantRepository(BaseDbContext context) : base(context)
    {
    }
}
