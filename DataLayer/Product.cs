using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer.Models;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Product : IDomainModel
    {
        public int Id { get; set; } = 0;

        public string Name { get; set; } = null;

        public int supplierid { get; set; }

        public int categoryid { get; set; }

        public Category Category { get; set; } = null;

        public string QuantityPerUnit { get; set; } = null;

        public double UnitPrice { get; set; } = 0.0;


        public int UnitsInStock { get; set; } = 0;

        public string CategoryName { get; set; } = null;
    }
}
