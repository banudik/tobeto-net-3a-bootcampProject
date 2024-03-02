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

public class EmployeeBusinessRules:BaseBusinessRules
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeBusinessRules(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task CheckUserNameIfExist(string userName, int? id)
    {

        var item = await _employeeRepository.GetAsync(x => x.UserName == SeoHelper.ToSeoUrl(userName) && x.Id != id);
        if (item != null)
        {
            throw new BusinessException(EmployeeMessages.UserNameCheck);
        }
    }

    public async Task CheckIdIfNotExist(int id)
    {
        var item = await _employeeRepository.GetAsync(x => x.Id == id);
        if (item == null)
        {
            throw new NotFoundException(EmployeeMessages.EmployeeIdCheck);
        }
    }
}
