
using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System.Security.Cryptography.X509Certificates;

namespace UI
{
    class Program
    {
        static void Main(string[] args)
        {

            //CompanyTest();
            //OrderTest();
            //ProductTest();

            

        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            productManager.Add(new Product { ProductName = "Car", Stock = 7000, Price = 150000 });

            foreach (var item in productManager.GetAll().Data)
            {
                Console.WriteLine("Product Id:{0} Product Name:{1} Stock:{2} Price:{3}", item.ProductId, item.ProductName, item.Stock, item.Price);
            }
            Console.ReadLine();
        }

        private static void OrderTest()
        {
            OrderManager orderManager = new OrderManager(new EfOrderDal(), new CompanyManager(new EfCompanyDal()), new ProductManager(new EfProductDal()));
            orderManager.Add(new Order { CompanyId = 4, ProductId=2, OrderPlacerName="Mehmet Yılmaz", OrderDate=DateTime.Now ,Quantity=250});

            foreach (var item in orderManager.GetAll().Data)
            {
                Console.WriteLine("Order Id:{0} OrderPlacerName:{1} OrderDate:{2} Quantity:{3}", item.OrderId, item.OrderPlacerName, item.OrderDate,item.Quantity);
            }
            Console.ReadLine();
        }

        private static void CompanyTest()
        {
            CompanyManager companyManager = new CompanyManager(new EfCompanyDal());
            companyManager.UpdateOnlyPermissionTimes(new Company { CompanyId = 4, ApprovalStatus = true, CompanyName = "Enoca", OrderPermissionStartTime = "05:00", OrderPermissionEndTime = "20:30" });

            foreach (var item in companyManager.GetAll().Data)
            {
                Console.WriteLine("Company Id:{0} Company Name:{1} Company Order Times: {2}-{3} Company Approval Status:{4}", item.CompanyId, item.CompanyName, item.OrderPermissionStartTime, item.OrderPermissionEndTime, item.ApprovalStatus);
            }
            Console.ReadLine();
        }
    }
}
