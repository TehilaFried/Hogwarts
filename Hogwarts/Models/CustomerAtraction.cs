using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hogwarts.Models
{
    public class CustomerAtraction
    {
        [Display(Name = "CustomerName")]
        public string CustomerId { get; set; }
        public Customer Customer { get; set; }

        [Display(Name = "Atraction")]
        public string AtractionId { get; set; }
        public Atractions Atractions { get; set; }
    }
}
