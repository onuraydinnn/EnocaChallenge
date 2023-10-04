using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Company : IEntity
    {
        public Company()
        {
            Orders = new List<Order>();
        }

        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public bool ApprovalStatus { get; set; }
        public string OrderPermissionStartTime { get; set; }
        public string OrderPermissionEndTime { get; set; }

        public List<Order> Orders { get; set; }
    }
}
