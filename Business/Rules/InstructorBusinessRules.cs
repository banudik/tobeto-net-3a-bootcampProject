using Business.Constants;
using Core.CrossCuttingConcerns.Rules;
using Core.Exceptions.Types;
using Core.Utilities.Helpers;
using DataAccess.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules;

public class InstructorBusinessRules:BaseBusinessRules
{
    private readonly IInstructorRepository _instructorRepository;

    public InstructorBusinessRules(IInstructorRepository instructorRepository)
    {
        _instructorRepository = instructorRepository;
    }

    public async Task CheckUserNameIfExist(string userName, int? id)
    {

        var item = await _instructorRepository.GetAsync(x => x.UserName == SeoHelper.ToSeoUrl(userName) && x.Id != id);
        if (item != null)
        {
            throw new BusinessException(InstructorMessages.UserNameCheck);
        }
    }

    public async Task CheckIdIfNotExist(int id)
    {
        var item = await _instructorRepository.GetAsync(x => x.Id == id);
        if (item == null)
        {
            throw new NotFoundException(InstructorMessages.InstructorIdCheck);
        }
    }
}
