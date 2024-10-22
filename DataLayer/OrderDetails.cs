using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class OrderDetails
    {
        public int OrderId { get; set; } = 0;

        public Order Order { get; set; } = null;

        public int ProductId { get; set; } = 0;
        public Product Product { get; set; } = null;

        public int UnitPrice { get; set; } = 0;

        public int Quantity { get; set; } = 0;

        public int Discount { get; set; } = 0;

    }
}
