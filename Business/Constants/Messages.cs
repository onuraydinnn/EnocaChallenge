using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CompanyAdded = "Company added";
        public static string ProductAdded = "Product added";
        public static string OrderAdded = "Order added";
        public static string CompanyPermissionError = "Company is not currently taking orders";
        public static string CompanyApprovalStatusError = "Company not approved";
        public static string ProductNotInStock = "Product quantity is not in stock";
    }
}
