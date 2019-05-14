using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hogwarts.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int QuentityDays { get; set; }
        public DateTime Time { get; set; }
        public DateTime date { get; set; }
        enum PaymentKind
        {
            visa,
            check,
            cash
        }



    }
}
