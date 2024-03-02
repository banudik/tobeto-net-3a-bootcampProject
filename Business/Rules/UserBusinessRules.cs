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

public class UserBusinessRules:BaseBusinessRules
{
    private readonly IUserRepository _userRepository;

    public UserBusinessRules(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task CheckIdIfNotExist(int id)
    {
        var item = await _userRepository.GetAsync(x => x.Id == id);
        if (item == null)
        {
            throw new NotFoundException(UserMessages.UserIdCheck);
        }
    }
}
