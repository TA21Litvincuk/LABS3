using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class Dish
    {
        public string Name { get; }
        public decimal Price { get; }

        public Dish(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }
}
