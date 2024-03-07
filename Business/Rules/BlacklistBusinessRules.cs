using Business.Constants;
using Core.CrossCuttingConcerns.Rules;
using Core.Exceptions.Types;
using DataAccess.Abstracts;

namespace Business.Rules;

public class BlacklistBusinessRules : BaseBusinessRules
{
    private readonly IBlacklistRepository _blacklistRepository;

    public BlacklistBusinessRules(IBlacklistRepository blacklistRepository)
    {
        _blacklistRepository = blacklistRepository;
    }

    public async Task CheckIdIfNotExist(int id)
    {
        var item = await _blacklistRepository.GetAsync(x => x.Id == id);
        if (item == null)
        {
            throw new NotFoundException(BlacklistMessages.BlacklistIdCheck);
        }
    }
    public async Task CheckIdIfExist(int id)
    {
        var item = await _blacklistRepository.GetAsync(x => x.Id == id);
        if (item != null)
        {
            throw new NotFoundException(BlacklistMessages.BlacklistIdCheck);
        }
    }

}
