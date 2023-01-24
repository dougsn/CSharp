using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comparacao_HashSet.Entities {
    internal class Product {

        public string Name { get; set; }
        public double Price { get; set; }

        public Product(string name, double price) {
            Name = name;
            Price = price;
        }

        public override bool Equals(object obj) {

            if (!(obj is Product)) {
                return false;
            }

            Product other = obj as Product;
            return Name.Equals(other.Name) && Price.Equals(other.Price);

            
        }

        public override int GetHashCode() {
            return HashCode.Combine(Name, Price);
        }
    }
}
