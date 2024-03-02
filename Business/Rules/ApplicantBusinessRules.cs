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

public class ApplicantBusinessRules:BaseBusinessRules
{
    private readonly IApplicantRepository _applicantRepository;

    public ApplicantBusinessRules(IApplicantRepository applicantRepository)
    {
        _applicantRepository = applicantRepository;
    }

    public async Task CheckUserNameIfExist(string userName, int? id)
    {

        var item = await _applicantRepository.GetAsync(x => x.UserName == SeoHelper.ToSeoUrl(userName) && x.Id != id);
        if (item != null)
        {
            throw new BusinessException(ApplicantMessages.UserNameCheck);
        }
    }

    public async Task CheckIdIfNotExist(int id)
    {
        var item = await _applicantRepository.GetAsync(x => x.Id == id);
        if (item == null)
        {
            throw new BusinessException(ApplicantMessages.ApplicantIdCheck);
        }

    }
}
