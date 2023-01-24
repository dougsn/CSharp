using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Produto_Heranca.Entities {
    internal class ImportedProduct : Product {

        public double CustomsFee { get; set; }

        public ImportedProduct(string name, double price, double customsFee) : base(name, price) {
            CustomsFee = customsFee;
        }

        public double TotalPrice() {
            return Price + CustomsFee;
        }

        public override string PriceTag() {
            return  $"${Name} $ {TotalPrice()} (Customs fee: ${CustomsFee})" ;
        }

    }
}
