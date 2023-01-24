using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Fixacao_Abstract_Methods.Entities {
    internal class Company : TaxPayer {

        public int NumberOfEmployees { get; set; }

        public Company(string name, double anualIncome, int numberOfEmployees) : base(name, anualIncome) {
            NumberOfEmployees = numberOfEmployees;
        }

        public override double Tax() {
            
            if(NumberOfEmployees > 10) {
                return AnualIncome * .14;
            } else {
                return AnualIncome * .16;
            }

        }
    }
}
