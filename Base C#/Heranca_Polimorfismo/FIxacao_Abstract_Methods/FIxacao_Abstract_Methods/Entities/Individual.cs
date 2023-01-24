using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fixacao_Abstract_Methods.Entities {
    internal class Individual : TaxPayer {

        public double HealthExpenditures{ get; set; }

        public Individual(string name, double anualIncome) : base(name, anualIncome){}

        public Individual(string name, double anualIncome, double healthExpenditures) : base(name, anualIncome) {
            HealthExpenditures = healthExpenditures;
        }

        public override double Tax() {

            if(AnualIncome < 20000.00) {
                return AnualIncome * .15 - HealthExpenditures * .5;               
            } else {
                return AnualIncome * .25 - HealthExpenditures * .5;
            }

        }
    }
}
