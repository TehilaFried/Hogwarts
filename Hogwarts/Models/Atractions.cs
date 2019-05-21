using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hogwarts.Models
{
    public class Atractions
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Kind { get; set; }
        public Locations Location { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }

        public DateTime Date { get; set; }
        public int DurationTime { get; set; }
        public double TicketPrice { get; set; }
        public ICollection<Orders> Orderses { get; set; }
        public ICollection<Customer> Customers { get; set; }

        public Locations Locations { get; set; }
    }
}
