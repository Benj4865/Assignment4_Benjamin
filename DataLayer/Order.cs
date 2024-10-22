using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Order : IDomainModel
    {
        public int Id { get; set; } = 0;

        public DateTime Date { get; set; } = new DateTime();

        public DateTime Required { get; set; } = new DateTime();

        public IList<Category> OrderDetails { get; set; } = null;

        public string ShipName { get; set; } = null;

        public string ShipCity { get; set; } = null;
    }
}
