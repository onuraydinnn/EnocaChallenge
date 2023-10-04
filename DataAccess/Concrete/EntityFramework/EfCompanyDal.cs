using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCompanyDal : EfEntityRepositoryBase<Company, CommerceContext>, ICompanyDal
    {
        public void UpdateOnlyApprovalStatus(Company company)
        {
            using (CommerceContext context = new CommerceContext())
            {
                var existingCompany = context.Companies.Find(company.CompanyId);

                if (existingCompany != null)
                {
                    existingCompany.ApprovalStatus = company.ApprovalStatus;
                    context.SaveChanges();
                }
            }
        }

        public void UpdateOnlyPermissionTimes(Company company)
        {
            using (CommerceContext context = new CommerceContext())
            {
                var existingCompany = context.Companies.Find(company.CompanyId);

                if (existingCompany != null)
                {
                    existingCompany.OrderPermissionStartTime = company.OrderPermissionStartTime;
                    existingCompany.OrderPermissionEndTime = company.OrderPermissionEndTime;
                    context.SaveChanges();
                }
            }
        }
    }
}
