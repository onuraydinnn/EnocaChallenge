using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICompanyService
    {
        IDataResult<List<Company>> GetAll();
        IResult Add(Company company);
        IResult Delete(Company company);
        IResult Update(Company company);
        IResult UpdateOnlyApprovalStatus(Company company);
        IResult UpdateOnlyPermissionTimes(Company company);
        IDataResult<Company> GetById(int companyId);
    }
}
