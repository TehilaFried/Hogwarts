using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hogwarts.Models
{
    public class Orders
    {
        public int Id { get; set; }
        public SignUpApplication SignUpApplication { get; set; }
        public Atractions Atractions { get; set; }
        public int NumOfTickets { get; set; }
        public double TotalCost { get; set; }
        public DateTime Time { get; set; }

        
        
        
    }
}
