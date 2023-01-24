using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa.Entities {
    internal class OutsourcedEmployee : Employee {

        public double AdditionalCharge { get; set; }

        
        public OutsourcedEmployee(string name, int hours, double valuePerHour, double AdditionalCharge ) : base(name, hours, valuePerHour) {
            this.AdditionalCharge = AdditionalCharge;
        }

        public override double Payment() {
            return base.Payment() + 1.1 * AdditionalCharge;
        }


    }
}
