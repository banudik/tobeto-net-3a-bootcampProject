using Business.Abstracts.Blacklists;
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

public class ApplicationBusinessRules: BaseBusinessRules
{
    private readonly IBlacklistService _blacklistService;
    private readonly IApplicationRepository _applicationRepository;

    public ApplicationBusinessRules(IBlacklistService blacklistService, IApplicationRepository applicationRepository)
    {
        _blacklistService = blacklistService;
        _applicationRepository = applicationRepository;
    }

    public async Task CheckIdIfNotExist(int id)
    {
        var item = await _applicationRepository.GetAsync(x => x.Id == id);
        if (item == null)
        {
            throw new NotFoundException(ApplicationMessages.ApplicationIdCheck);
        }
    }

    public async Task CheckIfApplicantIsBlacklisted(int id)
    {
        var item = await _blacklistService.GetByApplicantIdAsync(id); if (item.Data != null)
        {
            throw new BusinessException(ApplicationMessages.ApplicationBlacklisted);
        }
    }
}
