using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Action_ForEach.Entities {
    internal class Products {

        public string Name { get; set; }
        public double Price { get; set; }

        public Products(string name, double price) {
            Name = name;
            Price = price;
        }
    }
}
