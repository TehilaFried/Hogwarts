using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hogwarts.Models
{
    public class Comments
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public DateTime Date { get; set; }
        public bool Opinion { get; set; }
        public int Mark { get; set; }
        public string Content { get; set; }
       
    }
}
