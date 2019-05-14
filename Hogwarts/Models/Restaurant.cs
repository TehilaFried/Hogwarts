using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hogwarts.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        enum Day
        {
            Sunday,
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
 
        }
        public string OpenTime { get; set; }
        public string CloseTime { get; set; }
        enum Kind
        {
            Milky,
            Meat,
            Vegetarian
        }
    }
}
