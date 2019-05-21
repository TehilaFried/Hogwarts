using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hogwarts.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Address { get; set; }
        public int Age { get; set; }
        public int PhoneNumber { get; set; }
        public string MailAdress { get; set; }
        public Statuses Status { get; set; }

        public ICollection<Comments> Commentses { get; set; }
        public ICollection<Atractions> Atractionses { get; set; }

        public ICollection<SignUpApplication> SignUpApplications { get; set; }





    }
}
