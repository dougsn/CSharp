using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heranca_Polimorfismo.Entities {
    internal class SavingsAccount : Account { // O ':' é o extends, referencia a herança por Account
        public double InterestRate { get; set; }

        public SavingsAccount() {
        }

        public SavingsAccount(int number, string holder, double balance, double interestRate)
            : base(number, holder, balance) { // O base é igual ao super(), ele reaproveita o que já foi criado na superclasse.
            InterestRate = interestRate;
        }

        public void UpdateBalance() {
            Balance += Balance * InterestRate;
        }

        public override void Withdraw(double amount) {
            base.Withdraw(amount); // aproveita método e a lógica que já foi criado na superclasse.
            Balance -= amount;
        }

    }
}

