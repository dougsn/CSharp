using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heranca_Polimorfismo.Entities {
    internal class BussinesAccount : Account{ // O ':' é o extends, referencia a herança por Account
        public double LoanLimit { get; set; }

        public BussinesAccount() {
        }

        public BussinesAccount(int number, string holder, double balance, double loanLimit)
            : base(number, holder, balance) {
            LoanLimit = loanLimit;
        }

        public void Loan(double amount) {
            if (amount <= LoanLimit) {
                Balance += amount;
            }
        }
    }
}
