using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Order : IEntity
    {
        public int OrderId { get; set; }
        public int CompanyId { get; set; }
        public int ProductId { get; set; }
        public string OrderPlacerName { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }

        public Company Company { get; set; }
        public Product Product { get; set; }
    }
}
