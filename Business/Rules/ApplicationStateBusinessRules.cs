using Business.Constants;
using Core.CrossCuttingConcerns.Rules;
using Core.Exceptions.Types;
using DataAccess.Abstracts;
using DataAccess.Concretes.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules;

public class ApplicationStateBusinessRules: BaseBusinessRules
{
    private readonly IApplicationStateRepository _applicationStateRepository;

    public ApplicationStateBusinessRules(IApplicationStateRepository applicationStateRepository)
    {
        _applicationStateRepository = applicationStateRepository;
    }

    public async Task CheckIdIfNotExist(int id)
    {
        var item = await _applicationStateRepository.GetAsync(x => x.Id == id);
        if (item == null)
        {
            throw new NotFoundException(ApplicationStateMessages.ApplicationStateIdCheck);
        }
    }
}
