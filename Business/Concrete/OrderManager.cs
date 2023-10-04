using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        IOrderDal _orderDal;
        ICompanyService _companyService;
        IProductService _productService;
        public OrderManager(IOrderDal orderDal, ICompanyService companyService, IProductService productService)
        {
            _orderDal = orderDal;
            _companyService = companyService;
            _productService = productService;
        }
        public IResult Add(Order order)
        {
            IResult result = BusinessRules.Run(CheckApprovalStatusOfCompany(order.CompanyId),
                                                CheckIfInPermissionTime(order),
                                                CheckProductStock(order));
            if (result != null)
            {
                return result;
            }

            _orderDal.Add(order);
            return new SuccessResult(Messages.OrderAdded);
        }

        public IResult Delete(Order order)
        {
            _orderDal.Delete(order);
            return new SuccessResult();
        }

        public IDataResult<List<Order>> GetAll()
        {
            return new SuccessDataResult<List<Order>>(_orderDal.GetAll());
        }

        public IResult Update(Order order)
        {
            _orderDal.Update(order);
            return new SuccessResult();
        }

        private IResult CheckIfInPermissionTime(Order order)
        {
            var company = _companyService.GetById(order.CompanyId);

            if (company.Success)
            {
                TimeSpan startTime = TimeSpan.Parse(company.Data.OrderPermissionStartTime);
                TimeSpan endTime = TimeSpan.Parse(company.Data.OrderPermissionEndTime);

                TimeSpan orderTime = order.OrderDate.TimeOfDay;

                if (orderTime<startTime || orderTime > endTime)
                {
                    return new ErrorResult();
                }
                return new SuccessResult(Messages.CompanyPermissionError);
            }
            return new ErrorResult();
        }

        private IResult CheckApprovalStatusOfCompany(int companyId)
        {
            var company = _companyService.GetById(companyId);

            if (company == null)
            {
                return new ErrorResult("Company not found");
            }

            if (company.Success)
            {
                if (company.Data.ApprovalStatus)
                {
                    return new SuccessResult();
                }
                return new ErrorResult(Messages.CompanyApprovalStatusError);
            }
            return new ErrorResult();
        }

        private IResult CheckProductStock(Order order)
        {
            var product = _productService.GetById(order.ProductId);
            if (product.Success)
            {
                if (order.Quantity > product.Data.Stock)
                {
                    return new ErrorResult(Messages.ProductNotInStock);
                }
                return new SuccessResult();
            }
            return new SuccessResult();
        }



    }
}
