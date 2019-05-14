using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hogwarts.Models
{
    public class SignUpApplication
    {
        public int Id { get; set; }
        public Customer CostumerName { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

        enum PaymentKind
        {
            visa,
            check,
            cash
        } 

    }
}
