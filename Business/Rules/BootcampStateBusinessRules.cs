using Business.Constants;
using Core.CrossCuttingConcerns.Rules;
using Core.Exceptions.Types;
using DataAccess.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules;

public class BootcampStateBusinessRules:BaseBusinessRules
{
    private readonly IBootcampStateRepository _bootcampStateRepository;

    public BootcampStateBusinessRules(IBootcampStateRepository bootcampStateRepository)
    {
        _bootcampStateRepository = bootcampStateRepository;
    }

    public async Task CheckIdIfNotExist(int id)
    {
        var item = await _bootcampStateRepository.GetAsync(x => x.Id == id);
        if (item == null)
        {
            throw new NotFoundException(BootcampStateMessages.BootcampStateIdCheck);
        }
    }
}
