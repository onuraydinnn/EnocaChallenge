using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CompanyManager : ICompanyService
    {
        ICompanyDal _companyDal;
        public CompanyManager(ICompanyDal companyDal)
        {
            _companyDal = companyDal;
        }
        public IResult Add(Company company)
        {
            _companyDal.Add(company);
            return new SuccessResult(Messages.CompanyAdded);
        }

        public IResult Delete(Company company)
        {
            _companyDal.Delete(company);
            return new SuccessResult();
        }

        public IDataResult<List<Company>> GetAll()
        {
            return new SuccessDataResult<List<Company>>(_companyDal.GetAll());
        }

        public IResult Update(Company company)
        {
            _companyDal.Update(company);
            return new SuccessResult();
        }

        public IResult UpdateOnlyApprovalStatus(Company company)
        {
            _companyDal.UpdateOnlyApprovalStatus(company);
            return new SuccessResult();
        }

        public IResult UpdateOnlyPermissionTimes(Company company)
        {
            _companyDal.UpdateOnlyPermissionTimes(company);
            return new SuccessResult();
        }

        public IDataResult<Company> GetById(int companyId)
        {
            return new SuccessDataResult<Company>(_companyDal.Get(c => c.CompanyId == companyId));
        }




    }
}
