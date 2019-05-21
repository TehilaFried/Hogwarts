using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hogwarts.Models
{
    public class Statuses
    {
        public int Id { get; set; }
        public string StatusName { get; set; }
        public double Discount { get; set; }
        public ICollection<Customer> Customers { get; set; }
    }
}
