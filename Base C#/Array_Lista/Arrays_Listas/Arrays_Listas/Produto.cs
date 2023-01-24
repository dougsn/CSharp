using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays_Listas {
    internal class Produto {

        public string Name { get; set; }
        public double Price { get; set; }

        public Produto(string name, double price) {
            Name = name;
            Price = price;
        }
    }
}
