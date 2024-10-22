using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Category : IDomainModel
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = null;
        public string? Description { get; set; } = null;
    }
}
